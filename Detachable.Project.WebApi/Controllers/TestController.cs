﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Detachable.Project.Business;
using Detachable.Project.IBusiness;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Detachable.Project.WebApi.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class TestController : ControllerBase
{

    private readonly ILogger<TestController> _logger;
    private readonly ITest _test;
    private readonly TestNoInterface _testNoInterface;
    public TestController(ILogger<TestController> logger,ITest test, TestNoInterface testNoInterface)
    {
        _logger = logger;
        _test = test;
        _testNoInterface = testNoInterface;
    }

    [HttpGet]
    public async Task<string> HelloWorld()
    {
       await RedisHelper.SetAsync("helloworld_key","helloworld");
        return _test.GetValue();
    }
   
    [HttpGet]
    public async Task<string> GetYeah()
    {
        //_logger.LogInformation("hello world");
        return _testNoInterface.Get() + await RedisHelper.GetAsync("helloworld_key");
    }


    
    [HttpGet]
    public Task SetValue(string name,int value)
    {
        return Task.CompletedTask;
    }

}
