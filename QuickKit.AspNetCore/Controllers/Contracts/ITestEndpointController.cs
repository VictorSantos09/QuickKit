using Microsoft.AspNetCore.Mvc;

namespace QuickKit.AspNetCore.Controllers.Contracts;

/// <summary>
/// Represents an interface for testing the endpoint of a controller.
/// </summary>
public interface ITestEndpointController
{
    /// <summary>
    /// Tests the endpoint of the controller.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> representing the result of the test.</returns>
    IActionResult TestEndPoint();
}

