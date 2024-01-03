using System;

namespace 移动家客WinApp.Model.Output.Signin
{
    public class UserAndTokenDto
    {
        public TokenInfoDto token { get; set; }
        public UserInfoDto data { get; set; }
    }

    public class TokenInfoDto
    {
        public string access_token { get; set; }
        public float expires_in { get; set; }
        public DateTime expirestime { get; set; }
        public bool status { get; set; }
        public string token_type { get; set; }
    }

    public class UserInfoDto
    {
        public string id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile_no { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int usestateid { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType usertype { get; set; }

        public usergroup usergroup { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string realityname { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string registerphoto { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public string professiontype { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int logincount { get; set; } = 0;

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? loginTime { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public string organizationid { get; set; }

        /// <summary>
        /// 租户id
        /// </summary>
        public string tenantid { get; set; }

        /// <summary>
        /// 微信OpenID
        /// </summary>
        public string openid { get; set; } = string.Empty;

        public string IMSI { get; set; }
        public string test { get; set; }
    }

    public enum UserType
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        SuperAdministrator = 1,

        /// <summary>
        /// 运营管理员
        /// </summary>
        OperationsAdministrator = 2,

        /// <summary>
        /// 租户管理员
        /// </summary>
        TenantAdministrator = 3,

        /// <summary>
        /// 普通用户
        /// </summary>
        GeneralUser = 4
    }

    public enum usergroup
    {
        /// <summary>
        /// 移动用户
        /// </summary>
        mobileuser = 1,

        /// <summary>
        /// 代维用户
        /// </summary>
        DaiWeiuser = 2
    }
}