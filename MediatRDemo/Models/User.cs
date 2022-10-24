using Zack.Commons;

namespace MediatR.Models;

public class User : BaseEntity
{
    public int Id { get; init; }
    public DateTime CreateTime { get; init; }
    public string UserName { get; private set; }
    public int Credits { get; private  set; }
    
    //特征三,将其映射为数据表中的一列
    private string? passwordHash;
    //特征四，此成员变量只能从数据库中读取
    private string? remark;

    public string? Remark
    {
        get
        {
            return this.remark;
        }
    }
    
    //特征五，此属性不映射到数据库中
    public string? Tag { get; set; }

    public User(string yhm,string pwd)
    {
        this.UserName = yhm;
        this.CreateTime = DateTime.Now;
        this.Credits = 10;
        this.passwordHash = HashHelper.ComputeMd5Hash(pwd);
        AddDomainEvent(new NewUserNotification(yhm,this.CreateTime));
    }

    private User()
    {
        
    }

    public void ChangeUserName(string un)
    {
        if (un.Length>5)
        {
            Console.WriteLine("用户名长度不能大于5");
            return;
        }

        
        AddDomainEvent(new ChangeNameNotification(this.UserName,un));
        this.UserName = un;
    }

    public void ChangePassword(string pwd)
    {
        if (pwd.Length<3)
        {
            Console.WriteLine("密码长度不能小于3");
            return;
        }
        this.passwordHash = HashHelper.ComputeMd5Hash(pwd);
    }
}