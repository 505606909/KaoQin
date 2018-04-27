using System;

namespace KaoQin.Modules
{
    public class SettingMoudle
    {
        /// <summary>
        /// 是否自启动
        /// </summary>
        public bool AutoRun { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        public string UserNo { get; set; }
        /// <summary>
        /// 忆华考勤密码
        /// </summary>
        public string YhKqPwd { get; set; }
        /// <summary>
        /// 忆华考勤加班原因
        /// </summary>
        public string YhKqJbResion { get; set; }
        /// <summary>
        /// 员工自助密码
        /// </summary>
        public string YGZZPword { get; set; }
        /// <summary>
        /// 是否扣除加班餐时间
        /// </summary>
        public bool? HasRemoveDearTime { get; set; }

        public string Test = Guid.NewGuid().ToString();
    }
}
