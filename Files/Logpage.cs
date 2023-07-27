using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using FontAwesome.Sharp;
using System.Data.SqlClient;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Diagnostics.Eventing.Reader;

namespace couse_work_gad
{
    public partial class Logpage : Form
    {
        const string clientID = "153508487242-kaoocm5t1q4qvf5t7r2s3m9o27vvetqq.apps.googleusercontent.com";
        string redirectURI = string.Format("http://{0}:{1}/", IPAddress.Loopback, GetRandomUnusedPort()); // Replace with your desired redirect URI
        const string clientSecret = "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";
        const string authorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
        const string tokenEndpoint = "https://www.googleapis.com/oauth2/v4/token";
        const string userInfoEndpoint = "https://www.googleapis.com/oauth2/v3/userinfo";
        public Logpage()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public static string uname;
        public static string uemail;
        public static string user;
        public static string pwd;
        public static string UName
        {
            get { return uname; }
            set { uname = value; }
        }

        public static string UEmail
        {
            get { return uemail; }
            set { uemail = value; }
        }
        public static string User
        {
            get { return user; }
            set { user = value; }
        }
        public static string Pass
        {
            get { return pwd; }
            set { pwd = value; }
        }
        public static int GetRandomUnusedPort()
        {
            try
            {
                var listener = new TcpListener(IPAddress.Loopback, 0);
                listener.Start();
                var port = ((IPEndPoint)listener.LocalEndpoint).Port;
                listener.Stop();
                return port;
            }
            catch (SocketException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                User = txt_username.Text;
                Pass = txt_password.Text;

                con.Open();
                cmd = new SqlCommand("SELECT email,password FROM RegistrationsTB WHERE email='" + txt_username.Text + "' AND password='" + txt_password.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    this.Hide();
                    Home hm = new Home();
                    hm.ShowDialog();
                }
                else
                {
                    dr.Close();
                    cmd = new SqlCommand("SELECT email,password FROM superadminTB WHERE email='" + txt_username.Text + "' AND password='" + txt_password.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        this.Hide();
                        Staffdash stfd = new Staffdash();
                        stfd.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password");
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_create_Account_Click(object sender, EventArgs e)
        {
            this.Close();
            Registration obj=new Registration();
            obj.ShowDialog();
        }

        private async void btn_gsignIn_Click(object sender, EventArgs e)
        {
            // Generates state and PKCE values.
            string state = randomDataBase64url(32);
            string code_verifier = randomDataBase64url(32);
            string code_challenge = base64urlencodeNoPadding(sha256(code_verifier));
            const string code_challenge_method = "S256";

            // Creates a redirect URI using an available port on the loopback address.
            string redirectURI = string.Format("http://{0}:{1}/", IPAddress.Loopback, GetRandomUnusedPort());
            //output("redirect URI: " + redirectURI);

            // Creates an HttpListener to listen for requests on that redirect URI.
            var http = new HttpListener();
            http.Prefixes.Add(redirectURI);
            //output("Listening..");
            http.Start();

            // Creates the OAuth 2.0 authorization request.
            string authorizationRequest = string.Format("{0}?response_type=code&scope=email%20profile&redirect_uri={1}&client_id={2}&state={3}&code_challenge={4}&code_challenge_method={5}",
                authorizationEndpoint,
                System.Uri.EscapeDataString(redirectURI),
                clientID,
                state,
                code_challenge,
                code_challenge_method);

            // Opens request in the browser.
            System.Diagnostics.Process.Start(authorizationRequest);

            // Waits for the OAuth authorization response.
            var context = await http.GetContextAsync();

            // Brings this app back to the foreground.
            this.Hide();

            // Sends an HTTP response to the browser.
            var response = context.Response;
            string responseString = string.Format("<html><head><meta http-equiv='refresh' content='10;url=https://google.com'></head><body>Please return to the app.</body></html>");
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
            {
                responseOutput.Close();
                http.Stop();
                //Console.WriteLine("HTTP server stopped.");
            });

            // Checks for errors.
            if (context.Request.QueryString.Get("error") != null)
            {
                MessageBox.Show(String.Format("OAuth authorization error: {0}.", context.Request.QueryString.Get("error")));
                //output(String.Format("OAuth authorization error: {0}.", context.Request.QueryString.Get("error")));
                return;
            }
            if (context.Request.QueryString.Get("code") == null
                || context.Request.QueryString.Get("state") == null)
            {
                MessageBox.Show("Malformed authorization response. " + context.Request.QueryString);
                //output("Malformed authorization response. " + context.Request.QueryString);
                return;
            }

            // extracts the code
            var code = context.Request.QueryString.Get("code");
            var incoming_state = context.Request.QueryString.Get("state");

            // Compares the receieved state to the expected value, to ensure that
            // this app made the request which resulted in authorization.
            if (incoming_state != state)
            {
                MessageBox.Show(String.Format("Received request with invalid state ({0})", incoming_state));
                //output(String.Format("Received request with invalid state ({0})", incoming_state));
                return;
            }

            // Starts the code exchange at the Token Endpoint.
            performCodeExchange(code, code_verifier, redirectURI);
        }
        async void performCodeExchange(string code, string code_verifier, string redirectURI)
        {
            //output("Exchanging code for tokens...");

            // builds the  request
            string tokenRequestURI = "https://www.googleapis.com/oauth2/v4/token";
            string tokenRequestBody = string.Format("code={0}&redirect_uri={1}&client_id={2}&code_verifier={3}&client_secret={4}&scope=&grant_type=authorization_code",
                code,
                System.Uri.EscapeDataString(redirectURI),
                clientID,
                code_verifier,
                clientSecret
                );

            // sends the request
            HttpWebRequest tokenRequest = (HttpWebRequest)WebRequest.Create(tokenRequestURI);
            tokenRequest.Method = "POST";
            tokenRequest.ContentType = "application/x-www-form-urlencoded";
            tokenRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            byte[] _byteVersion = Encoding.ASCII.GetBytes(tokenRequestBody);
            tokenRequest.ContentLength = _byteVersion.Length;
            Stream stream = tokenRequest.GetRequestStream();
            await stream.WriteAsync(_byteVersion, 0, _byteVersion.Length);
            stream.Close();

            try
            {
                // gets the response
                WebResponse tokenResponse = await tokenRequest.GetResponseAsync();
                using (StreamReader reader = new StreamReader(tokenResponse.GetResponseStream()))
                {
                    // reads response body
                    string responseText = await reader.ReadToEndAsync();
                    //output(responseText);

                    // converts to dictionary
                    Dictionary<string, string> tokenEndpointDecoded = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText);

                    string access_token = tokenEndpointDecoded["access_token"];
                    userinfoCall(access_token);
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = ex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        MessageBox.Show("HTTP: " + response.StatusCode);
                        //output("HTTP: " + response.StatusCode);
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            // reads response body
                            string responseText = await reader.ReadToEndAsync();
                            MessageBox.Show(responseText);
                            //output(responseText);
                        }
                    }

                }
            }
        }
        async void userinfoCall(string access_token)
        {
            //output("Making API Call to Userinfo...");

            // builds the  request
            string userinfoRequestURI = "https://www.googleapis.com/oauth2/v3/userinfo";

            // sends the request
            HttpWebRequest userinfoRequest = (HttpWebRequest)WebRequest.Create(userinfoRequestURI);
            userinfoRequest.Method = "GET";
            userinfoRequest.Headers.Add(string.Format("Authorization: Bearer {0}", access_token));
            userinfoRequest.ContentType = "application/x-www-form-urlencoded";
            userinfoRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

            // gets the response
            WebResponse userinfoResponse = await userinfoRequest.GetResponseAsync();
            using (StreamReader userinfoResponseReader = new StreamReader(userinfoResponse.GetResponseStream()))
            {
                // reads response body
                string userinfoResponseText = await userinfoResponseReader.ReadToEndAsync();

                UEmail = ParseEmailFromResponse(userinfoResponseText);
                UName = ParseNameFromResponse(userinfoResponseText);

                ParseToForm();
            }
        }
        private string ParseEmailFromResponse(string responseText)
        {
            try
            {
                dynamic responseJson = JsonConvert.DeserializeObject(responseText);
                string email = responseJson.email;
                return email;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing email from API response: " + ex.Message);
                return string.Empty;
            }
        }
        private string ParseNameFromResponse(string responseText)
        {
            try
            {
                dynamic responseJson = JsonConvert.DeserializeObject(responseText);
                string name = responseJson.name;
                return name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing name from API response: " + ex.Message);
                return string.Empty;
            }
        }
        private void ParseToForm()
        {
            con = new SqlConnection("Data Source=sql-db-server1.database.windows.net;Initial Catalog=airlinedb;PersistSecurityInfo=True;User ID=adminayesh;Password=Ayesh123456");
            con.Open();
            cmd = new SqlCommand("SELECT * FROM googleregistration WHERE email='" + UEmail + "'", con);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.Hide();
                Home hm = new Home();
                hm.Show();
            }
            else
            {
                this.Hide();
                GoogleREG gr = new GoogleREG();
                gr.Show();
            }
        }
        /// <summary>
        /// Returns URI-safe data with a given input length.
        /// </summary>
        /// <param name="length">Input length (nb. output will be longer)</param>
        /// <returns></returns>
        public static string randomDataBase64url(uint length)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[length];
            rng.GetBytes(bytes);
            return base64urlencodeNoPadding(bytes);
        }

        /// <summary>
        /// Returns the SHA256 hash of the input string.
        /// </summary>
        /// <param name="inputStirng"></param>
        /// <returns></returns>
        public static byte[] sha256(string inputStirng)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(inputStirng);
            SHA256Managed sha256 = new SHA256Managed();
            return sha256.ComputeHash(bytes);
        }

        /// <summary>
        /// Base64url no-padding encodes the given input buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string base64urlencodeNoPadding(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer);

            // Converts base64 to base64url.
            base64 = base64.Replace("+", "-");
            base64 = base64.Replace("/", "_");
            // Strips padding.
            base64 = base64.Replace("=", "");

            return base64;
        }

        private void Logpage_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=sql-db-server1.database.windows.net;Initial Catalog=airlinedb;Persist Security Info=True;User ID=adminayesh;Password=Ayesh123456");
        }
    }
}
