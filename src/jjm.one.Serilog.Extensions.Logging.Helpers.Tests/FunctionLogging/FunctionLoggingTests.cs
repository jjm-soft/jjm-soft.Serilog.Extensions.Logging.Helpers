using System;
using System.Reflection;
using Moq;
using Serilog.Events;
using Serilog;

namespace jjm.one.Serilog.Extensions.Logging.Helpers.Tests.FunctionLogging;

/// <summary>
/// This class contains the tests for the <see cref="FunctionLogging"/> class.
/// </summary>
public class FunctionLoggingTests
{
    #region private members
    
    private readonly Mock<ILogger> _logger;
    
    #endregion

    #region ctors

    /// <summary>
    /// The default constructor of the <see cref="FunctionLoggingTests"/> class.
    /// </summary>
    public FunctionLoggingTests()
    {
        _logger = new Mock<ILogger>();
    }

    #endregion

    #region tests

    /// <summary>
    /// 1. test of the LogFctCall function.
    /// </summary>
    [Fact]
    public void LogFctCallTest1()
    {
        // arrange
        _logger.Setup(x => x.Write(LogEventLevel.Debug, 
            It.IsAny<string>(), It.IsAny<object?[]?>())).Verifiable();

        // act 
        _logger.Object.LogFctCall();

        // assert
        _logger.Verify(x => x.Write(LogEventLevel.Debug,
                "Function called: {ClassName} -> {FctName}", 
                nameof(FunctionLoggingTests), nameof(LogFctCallTest1)),
                Times.Once);
    }
    
    /// <summary>
    /// 2. test of the LogFctCall function.
    /// </summary>
    [Fact]
    public void LogFctCallTest2()
    {
        // arrange
        _logger.Setup(x => x.Write(LogEventLevel.Debug, 
            It.IsAny<string>(), It.IsAny<object?[]?>())).Verifiable();

        // act 
        _logger.Object.LogFctCall(GetType(), MethodBase.GetCurrentMethod());

        // assert
        _logger.Verify(x => x.Write(LogEventLevel.Debug,
                "Function called: {ClassName} -> {FctName}", 
                nameof(FunctionLoggingTests), nameof(LogFctCallTest2)),
            Times.Once);
    }
    
    /// <summary>
    /// 1. test of the LogExcInFctCall function.
    /// </summary>
    [Fact]
    public void LogExcInFctCallTest1()
    {
        // arrange
        var exc = new Exception("Test");
        _logger.Setup(x => x.Write(LogEventLevel.Debug, It.IsAny<Exception>(),
            It.IsAny<string>(), It.IsAny<object?[]?>())).Verifiable();

        // act 
        _logger.Object.LogExcInFctCall(exc);

        // assert
        _logger.Verify(x => x.Write(LogEventLevel.Error,
                It.Is<Exception>(e => e == exc),
                "Exception thrown in: {ClassName} -> {FctName}{CustomMsg}", 
                nameof(FunctionLoggingTests), nameof(LogExcInFctCallTest1), 
                string.Empty),
            Times.Once);
    }
    
    /// <summary>
    /// 2. test of the LogExcInFctCall function.
    /// </summary>
    [Fact]
    public void LogExcInFctCallTest2()
    {
        // arrange
        var exc = new Exception("Test");
        _logger.Setup(x => x.Write(LogEventLevel.Debug, It.IsAny<Exception>(),
            It.IsAny<string>(), It.IsAny<object?[]?>())).Verifiable();

        // act 
        _logger.Object.LogExcInFctCall(exc, "TestMSG");

        // assert
        _logger.Verify(x => x.Write(LogEventLevel.Error,
                It.Is<Exception>(e => e == exc),
                "Exception thrown in: {ClassName} -> {FctName}{CustomMsg}", 
                nameof(FunctionLoggingTests), nameof(LogExcInFctCallTest2),
        "\nTestMSG"),
            Times.Once);
    }
    
    /// <summary>
    /// 3. test of the LogExcInFctCall function.
    /// </summary>
    [Fact]
    public void LogExcInFctCallTest3()
    {
        // arrange
        var exc = new Exception("Test");
        _logger.Setup(x => x.Write(LogEventLevel.Debug, It.IsAny<Exception>(),
            It.IsAny<string>(), It.IsAny<object?[]?>())).Verifiable();

        // act 
        _logger.Object.LogExcInFctCall(exc, GetType(), 
            MethodBase.GetCurrentMethod());

        // assert
        _logger.Verify(x => x.Write(LogEventLevel.Error,
                It.Is<Exception>(e => e == exc),
                "Exception thrown in: {ClassName} -> {FctName}{CustomMsg}", 
                nameof(FunctionLoggingTests), nameof(LogExcInFctCallTest3),
                string.Empty),
            Times.Once);
    }
    
    /// <summary>
    /// 4. test of the LogExcInFctCall function.
    /// </summary>
    [Fact]
    public void LogExcInFctCallTest4()
    {
        // arrange
        var exc = new Exception("Test");
        _logger.Setup(x => x.Write(LogEventLevel.Debug, It.IsAny<Exception>(),
            It.IsAny<string>(), It.IsAny<object?[]?>())).Verifiable();

        // act 
        _logger.Object.LogExcInFctCall(exc, GetType(), 
            MethodBase.GetCurrentMethod(), "TestMSG");

        // assert
        _logger.Verify(x => x.Write(LogEventLevel.Error,
                It.Is<Exception>(e => e == exc),
                "Exception thrown in: {ClassName} -> {FctName}{CustomMsg}", 
                nameof(FunctionLoggingTests), nameof(LogExcInFctCallTest4),
                "\nTestMSG"),
            Times.Once);
    }

    #endregion
}