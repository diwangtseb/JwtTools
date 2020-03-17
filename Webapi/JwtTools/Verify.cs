using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace JwtTools
{
    public class Verify
    {
        public static string secret = "Wangdihencool";
        /// <summary>
        /// jwt加密算法
        /// </summary>
        /// <param name="payload">用户对象</param>
        /// <param name="secret">关键key</param>
        /// <returns></returns>
        public static string JwtEncoder(Dictionary<string, object> payload, string secret)
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();//hash256加密算法
            IJsonSerializer serializer = new JsonNetSerializer();//json序列化和反序列
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//base64编码
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);//加密
            try
            {
                return encoder.Encode(payload, secret);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string JwtDecoder(string token, string secret)
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();//hash256加密算法
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//base64编码
            IJsonSerializer serializer = new JsonNetSerializer();//json序列化和反序列
            IDateTimeProvider timeProvider = new UtcDateTimeProvider();//utc时间用以解码
            IJwtValidator validator = new JwtValidator(serializer, timeProvider);//解码校验
            IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);//解密
            try
            {
                return decoder.Decode(token, secret, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string Validelogin(HttpRequestHeaders headers)
        {
            if (headers.GetValues("token") == null || headers.GetValues("token").Any())
            {
                throw new Exception("请登录");
            }

            return JwtDecoder(headers.GetValues("token").First(), secret);
        }
    }
}
