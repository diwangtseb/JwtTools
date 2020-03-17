using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace jwtdemo
{
    class Program
    {
        static IJwtAlgorithm algorithm = new HMACSHA256Algorithm();//HMACSHA256加密
        static IJsonSerializer serializer = new JsonNetSerializer();//序列化和反序列
        static IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//Base64编解码
        static IDateTimeProvider provider = new UtcDateTimeProvider();//UTC时间获取
        static void Main(string[] args)
        {
            var payload = new Dictionary<string, object>()
            {
                {"UserId",123 }, {"UserName","admin" }
            };
            var secret = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC4aKpVo2OHXPwb1R7duLgg";
            //加密
            IJwtEncoder encoder=new JwtEncoder(algorithm,serializer,urlEncoder);
            string a = encoder.Encode(payload, secret);
            var b = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJVc2VySWQiOjEyMywiVXNlck5hbWUiOiJhZG1pbiJ9.z3ba6ryibxm3QJSfupAcyS1xwO8j7nPbcSQJ1nwDVXU";
            //解密
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);
            var a2=decoder.Decode(b, secret, true);
            Console.WriteLine(a2);
        }





        
    }
}
