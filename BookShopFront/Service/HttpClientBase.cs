﻿namespace BookShopBlazor.Service
{
    public class HttpClientBase
    {
        protected HttpClient httpClient;
        public HttpClientBase(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

    }
}
