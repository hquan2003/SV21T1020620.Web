﻿namespace SV21T1020620.BusinessLayers
{
    public static class Configuration
    {
        private static string connectionString = "";
        /// <summary>
        /// Khỏi tạo cấu hình cho BusinessLayer
        /// </summary>
        /// <param name="connectionString"></param>
        public static void Initialize(string connectionString)
        {
            Configuration.connectionString = connectionString;
        }
        /// <summary>
        /// Chuỗi tham số kết nối CSDL
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }
    }
}
