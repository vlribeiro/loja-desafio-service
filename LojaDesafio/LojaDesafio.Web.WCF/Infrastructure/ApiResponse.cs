﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaDesafio.Web.WCF.Infrastructure
{
    public class ApiResponse
    {
        public object Data { get; set; }
        public string Message { get; set; }

        public ApiResponse() { }

        public ApiResponse(object data)
        {
            this.Data = data;
            this.Message = "OK";
        }
    }
}