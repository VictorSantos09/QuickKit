using Microsoft.AspNetCore.Mvc;
using QuickKit.Api.Constants;

namespace QuickKit.Api;

[AttributeUsage(AttributeTargets.Method)]
public class HttpGetAllKit : HttpGetAttribute
{   
    public HttpGetAllKit(string template = ENDPOINT_TEMPLATE_NAME_CNT.GET_ALL) : base(template)
    {
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class HttpGetByIdKit : HttpGetAttribute
{
    public HttpGetByIdKit(string template = ENDPOINT_TEMPLATE_NAME_CNT.GET_BY_ID) : base(template)
    { }
}

[AttributeUsage(AttributeTargets.Method)]
public class HttpGetTestEndPointKit : HttpGetAttribute
{
    public HttpGetTestEndPointKit(string template = ENDPOINT_TEMPLATE_NAME_CNT.TEST) : base(template)
    { }
}

[AttributeUsage(AttributeTargets.Method)]
public class HttpAddKit : HttpPostAttribute
{
    public HttpAddKit(string template = ENDPOINT_TEMPLATE_NAME_CNT.ADD) : base(template)
    { }
}

[AttributeUsage(AttributeTargets.Method)]
public class HttpUpdateKit : HttpPutAttribute
{
    public HttpUpdateKit(string template = ENDPOINT_TEMPLATE_NAME_CNT.UPDATE) : base(template)
    { }
}

[AttributeUsage(AttributeTargets.Method)]
public class HttpDeleteKit : HttpDeleteAttribute
{
    public HttpDeleteKit(string template = ENDPOINT_TEMPLATE_NAME_CNT.DELETE) : base(template)
    { }
}
