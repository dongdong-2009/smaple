using System;
using System.Collections.Generic;
using System.Text;

//原型设计模式 实现深拷贝
class Resume:ICloneable
{
    private string name;
    private string sex;
    private string age;
    private WorkExperience work;

    public Resume()
    {

    }

    public Resume(string name,string sex,string age)
    {
        this.name = name;
        this.sex = sex;
        this.age = age;
    }

    /// <summary>
    /// 提供Clone方法调用的私有构造函数，以便克隆WorkExperience的数据
    /// </summary>
    /// <param name="work"></param>
    private Resume(WorkExperience work)
    {
        this.work = (WorkExperience)work.Clone();
    }

    public object Clone()
    {
        Resume obj = new Resume(this.work);
        obj.name = this.name;
        obj.age = this.age;
        obj.sex = this.sex;
        return obj;
    }
}

class WorkExperience : ICloneable
{

    private string year;
    /// <summary>
    /// 工作年限
    /// </summary>
    public string Year
    {
        get { return year; }
        set { year = value; }
    }

    private string company;
    /// <summary>
    /// 公司
    /// </summary>
    public string Company
    {
        get { return company; }
        set { company = value; }
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

