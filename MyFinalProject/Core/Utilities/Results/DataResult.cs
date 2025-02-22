﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message):base(success,message) //başarılıysa çalıştırılıyor ve başarılı olduğuna dair mesaj gönderiyor
        {
            Data = data;
        }
        public DataResult(T data,bool success):base(success)//mesaj döndürmeyen için constructor
        {
            Data = data;
        }
        public T Data { get; }
    }
}
