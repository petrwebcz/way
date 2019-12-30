namespace WhereAreYou.Core.Intefaces
{
    public interface IUrlSettings
    {
        string BaseInviteUrl { get; set; }
        string WebUrl { get; set; }
        string MeetApiUrl { get; set; }
        string SsoApiUrl { get; set; }
    }
}