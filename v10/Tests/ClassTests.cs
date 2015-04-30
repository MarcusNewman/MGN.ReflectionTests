using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MGN.ReflectionTests.Tests
{
    [TestClass]
    public class ClassTests : ReflectionTestTests
    {
        

        /// <summary>
        /// Class method should fail with an invalid assembly name.
        /// </summary>
        //[TestMethod]
        //public void Class_method_should_fail_with_an_invalid_assembly_name()
        //{
        //    var assemblyName = "InvalidAssemblyName";
        //    TestClassMethod(assemblyName: assemblyName, shouldFail: true);
        //}

        /// <summary>
        /// Class method should fail with an invalid class name.
        /// </summary>
        //[TestMethod]
        //public void Class_method_should_fail_with_an_invalid_class_name()
        //{
        //    var className = "InvalidClassName";
        //    TestClassMethod(className: className, shouldFail: true);
        //}

        /// <summary>
        /// Class method should return a Type with valid assembly and class names.
        /// </summary>
        //[TestMethod]
        //public void Class_method_should_return_a_Type()
        //{
        //    TestClassMethod();
        //}

        /// <summary>
        /// Tests for the existance of the Method method.
        /// </summary>
        //[TestMethod]
        //public void Method_method_should_exist()
        //{
        //    GetMethodMethod();
        //}

        /// <summary>
        /// Method method should fail with an invalid assembly name.
        /// </summary>
        //[TestMethod]
        //public void Method_method_should_fail_with_an_invalid_assembly_name()
        //{
        //    var assemblyName = "InvalidAssemblyName";
        //    TestMethodMethod(assemblyName: assemblyName, shouldFail: true);
        //}

        /// <summary>
        /// Method method should fail with an invalid class name.
        /// </summary>
        //[TestMethod]
        //public void Method_method_should_fail_with_an_invalid_class_name()
        //{
        //    var className = "InvalidClassName";
        //    TestMethodMethod(className: className, shouldFail: true);
        //}

        /// <summary>
        /// Method method should fail with an invalid method name.
        /// </summary>
        //[TestMethod]
        //public void Method_method_should_fail_with_an_invalid_method_name()
        //{
        //    var methodName = "InvalidMethodName";
        //    TestMethodMethod(methodName: methodName, shouldFail: true);
        //}

        /// <summary>
        /// Method method should return a memberInfo with valid assembly, class and method names.
        /// </summary>
        //[TestMethod]
        //public void Method_method_should_return_a_MethodInfo()
        //{
        //    TestMethodMethod();
        //}

        
        //private Type TestClassMethod(String className = "Assembly", String assemblyName = "MGN.ReflectionTests", Boolean shouldFail = false)
        //{
        //    var methodInfo = GetClassMethod();
        //    var parameters = new Object[] { assemblyName, className };
        //    return (Type)InvokeMethod(methodInfo: methodInfo, parameters: parameters, shouldFail: shouldFail);
        //}
        //private MethodInfo GetMethodMethod()
        //{
        //    var methodName = "Method";
        //    var parameterTypes = new Type[] { typeof(String), typeof(String), typeof(String) };
        //    var returnType = typeof(MethodInfo);
        //    return TestMethod(methodName, parameterTypes, returnType);
        //}
        //private MethodInfo TestMethodMethod(String methodName = "Test", String className = "Assembly", String assemblyName = "MGN.ReflectionTests", Boolean shouldFail = false)
        //{
        //    var methodInfo = GetMethodMethod();
        //    var parameters = new Object[] { assemblyName, className, methodName };
        //    return (MethodInfo)InvokeMethod(methodInfo: methodInfo, parameters: parameters, shouldFail: shouldFail);
        //}
        //private MethodInfo GetConstructorMethod()
        //{
        //    var methodName = "Constructor";
        //    var parameterTypes = new Type[] { typeof(String), typeof(String) };
        //    var returnType = typeof(MethodInfo);
        //    return TestMethod(methodName, parameterTypes, returnType);
        //}
    }
}
