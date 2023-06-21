using System;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace jjm.one.Microsoft.Extensions.Logging.Helpers.Tests.util;

public class DummyClass
{
    #region private members

    private readonly ILogger _logger;

    #endregion

    #region ctor

    public DummyClass(ILogger logger)
    {
        _logger = logger;
    }

    #endregion

    #region public methods

    public void Test1()
    {
        _logger.LogFctCall();
    }

    public void Test2()
    {
        _logger.LogFctCall(GetType(), MethodBase.GetCurrentMethod());
    }
    
    public void Test3()
    {
        _logger.LogExcInFctCall(new Exception("Test"));
    }

    public void Test4()
    {
        _logger.LogExcInFctCall(new Exception("Test"), "TestMSG");
    }

    public void Test5()
    {
        _logger.LogExcInFctCall(new Exception("Test"), GetType(), 
            MethodBase.GetCurrentMethod());
    }
    
    public void Test6()
    {
        _logger.LogExcInFctCall(new Exception("Test"), GetType(), 
            MethodBase.GetCurrentMethod(), "TestMSG");
    }
    
    #endregion
}