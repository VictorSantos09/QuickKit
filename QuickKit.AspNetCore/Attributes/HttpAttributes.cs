using Microsoft.AspNetCore.Mvc;
using QuickKit.AspNetCore.Constants;

namespace QuickKit.AspNetCore.Attributes;

#region GetAll
/// <summary>
/// Represents an attribute that specifies an HTTP GET request to retrieve all data.
/// <para>Does not define the data.</para>
/// <para>Does not define the response.</para>
/// <para>Uses the naming convention from <see cref="ENDPOINT_NAME_CNT_KIT.GET_ALL"/></para>
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class HttpGetAllKit : HttpGetAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpGetAllKit"/> class with the specified template.
    /// </summary>
    /// <param name="template">The template for the endpoint.</param>
    public HttpGetAllKit(string template = ENDPOINT_NAME_CNT_KIT.GET_ALL) : base(template)
    {
    }
}
#endregion

#region GetById
/// <summary>
/// Represents an attribute that specifies an HTTP GET request for retrieving a resource by its ID.
/// <para>Does not define the data.</para>
/// <para>Does not define the response.</para>
/// <para>Uses the naming convention from <see cref="ENDPOINT_NAME_CNT_KIT.GET_BY_ID"/></para>
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class HttpGetByIdKit : HttpGetAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpGetByIdKit"/> class with the specified template.
    /// 
    /// <para>Does not define the data.</para>
    /// <para>Does not define the response.</para>
    /// <para>Uses the naming convention from <see cref="ENDPOINT_NAME_CNT_KIT.GET_BY_ID"/></para>
    /// </summary>
    /// <param name="template">The template for the endpoint.</param>
    public HttpGetByIdKit(string template = ENDPOINT_NAME_CNT_KIT.GET_BY_ID) : base(template)
    { }
}

#endregion

#region TestEndPoint
/// <summary>
/// Represents an attribute that specifies an HTTP GET for test endpoint.
/// <para>Does not define the data.</para>
/// <para>Does not define the response.</para>
/// <para>Uses the naming convention from <see cref="ENDPOINT_NAME_CNT_KIT.TEST"/></para>
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class HttpGetTestEndPointKit : HttpGetAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpGetTestEndPointKit"/> class with the specified template.
    /// </summary>
    /// <param name="template">The template for the endpoint.</param>
    public HttpGetTestEndPointKit(string template = ENDPOINT_NAME_CNT_KIT.TEST) : base(template)
    { }
}

#endregion

#region Add
/// <summary>
/// Represents an attribute that is used to add a resource using HTTP POST method.
/// <para>Does not define the data.</para>
/// <para>Does not define the response.</para>
/// <para>Uses the naming convention from <see cref="ENDPOINT_NAME_CNT_KIT.ADD"/></para>
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class HttpAddKit : HttpPostAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpAddKit"/> class with the specified template.
    /// </summary>
    /// <param name="template">The template for the endpoint.</param>
    public HttpAddKit(string template = ENDPOINT_NAME_CNT_KIT.ADD) : base(template)
    { }
}

#endregion

#region Update
/// <summary>
/// Represents an attribute that is used to decorate a method as an HTTP update endpoint.
/// <para>Does not define the data.</para>
/// <para>Does not define the response.</para>
/// <para>Uses the naming convention from <see cref="ENDPOINT_NAME_CNT_KIT.UPDATE"/></para>
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class HttpUpdateKit : HttpPutAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpUpdateKit"/> class with the specified template.
    /// </summary>
    /// <param name="template">The template for the endpoint.</param>
    public HttpUpdateKit(string template = ENDPOINT_NAME_CNT_KIT.UPDATE) : base(template)
    { }
}

#endregion

#region Delete

/// <summary>
/// Represents an attribute that specifies that an action method should be accessible via HTTP DELETE requests.
/// <para>Does not define the data.</para>
/// <para>Does not define the response.</para>
/// <para>Uses the naming convention from <see cref="ENDPOINT_NAME_CNT_KIT.DELETE"/></para>
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class HttpDeleteKit : HttpDeleteAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HttpDeleteKit"/> class with the specified template.
    /// </summary>
    /// <param name="template">The template for the endpoint.</param>
    public HttpDeleteKit(string template = ENDPOINT_NAME_CNT_KIT.DELETE) : base(template)
    { }
}

#endregion