using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;

namespace WebApplication1
{
    public class JwtTools
    {
        public static string Key
        {
            get { return "778"; }
        }
        
        //加密
        public static string Encode(Dictionary<string,object>payload,string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                key = Key;
            }
            IJwtAlgorithm algorithm=new HMACSHA256Algorithm();
            IJsonSerializer jsonSerializer=new JsonNetSerializer();
            IBase64UrlEncoder ulEncoder=new JwtBase64UrlEncoder();
            IJwtEncoder encoder=new JwtEncoder(algorithm,jsonSerializer,ulEncoder);
            var token=encoder.Encode(payload, key);
            return token;
        }
        //解密
        public static Dictionary<string,object> Decode(string token)
        {
            IJwtDecoder decoder=
                new JwtDecoder(new JsonNetSerializer(),new JwtValidator(new JsonNetSerializer(),
                    new UtcDateTimeProvider() ), new JwtBase64UrlEncoder(),new HMACSHA256Algorithm());
            var decode=decoder.Decode(token);
            var deserialize=JsonConvert.DeserializeObject<Dictionary<string, object>>(decode);
            return deserialize;
        }
    }
}