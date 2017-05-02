        private string Get_PostData()
        {
            //int length =(int)Request.InputStream.Length;
            //byte[] b = new byte[length - 1];
            //Request.InputStream.Position = 0;
            //Request.InputStream.Read(b, 0, length);
            //return System.Text.Encoding.UTF8.GetString(b);

            System.IO.Stream s = Request.InputStream;
            int count = 0;
            byte[] buffer = new byte[1024];
            StringBuilder builder = new StringBuilder();
            while ((count = s.Read(buffer, 0, 1024)) > 0)
            {
                builder.Append(Encoding.UTF8.GetString(buffer, 0, count));
            }
            return builder.ToString();
        }