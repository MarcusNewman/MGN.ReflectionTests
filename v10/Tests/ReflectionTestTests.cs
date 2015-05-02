using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MGN.ReflectionTests.Tests
{
    [TestClass]
    public class ReflectionTestTests
    {
        const string AssemblyName = "MGN.ReflectionTests";

        /// <summary>
        /// Tests for the existance of the MGN.ReflectionTests assembly.
        /// </summary>
        [TestMethod]
        public void MGN_ReflectionTests_assembly_should_exist()
        {
            GetAssembly();
        }

        static Assembly GetAssembly()
        {
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFrom(assemblyFile: "..\\..\\..\\bin\\Debug\\" + AssemblyName + ".dll");
            }
            catch (System.IO.FileNotFoundException)
            {
                Assert.Fail(message: AssemblyName + " assembly was not found.");
            }
            return assembly;
        }

        /// <summary>
        /// Tests for the existance of the ReflectionTest class.       
        /// </summary>
        [TestMethod]
        public void ReflectionTest_class_should_exist()
        {
            GetClasstype();
        }

        static Type GetClasstype()
        {
            var assembly = GetAssembly();
            var classtype = assembly.GetType(AssemblyName + ".ReflectionTest");
            Assert.IsNotNull(value: classtype, message: "The ReflectionTest class should exist.");
            return classtype;
        }

        /// <summary>
        /// Tests for the existance of the Assembly method.
        /// </summary>
        [TestMethod]
        public void Assembly_method_should_exist()
        {
            GetAssemblyMethod();
        }

        static MethodInfo GetAssemblyMethod()
        {
            var methodName = "Assembly";
            var parameterTypes = new Type[] { typeof(String) };
            var returnType = typeof(Assembly);
            return GetMethod(methodName: methodName, parameterTypes: parameterTypes, returnType: returnType);
        }

        static MethodInfo GetMethod(string methodName, Type[] parameterTypes, Type returnType)
        {
            var classtype = GetClasstype();
            var methodInfo = classtype.GetMethod(name: methodName);
            var methodParameters = methodInfo.GetParameters();
            Assert.IsTrue(condition: methodParameters.Length == parameterTypes.Length, message: methodName + " method should accept " + parameterTypes.Length + " parameter(s).");
            for (var i = 0; i < methodParameters.Length; i++)
            {
                Assert.IsTrue(condition: methodParameters[i].ParameterType == parameterTypes[i], message: methodName + " parameter " + i.ToString() + " should be of type " + parameterTypes[i].ToString() + ".");
            }
            Assert.IsTrue(condition: methodInfo.IsStatic, message: methodName + " method should be static.");
            Assert.IsTrue(condition: methodInfo.ReturnType == returnType, message: methodName + " method return type should be " + returnType.ToString() + ".");
            return methodInfo;
        }

        /// <summary>
        /// Assembly method should fail with an invalid assembly name.
        /// </summary>
        [TestMethod]
        public void Assembly_method_should_fail_with_an_invalid_assembly_name()
        {
            var methodInfo = GetAssemblyMethod();
            var parameters = new String[] { "InvalidAssemblyName" };
            TestAssemblyMethod(methodInfo: methodInfo, parameters: parameters, shouldFail: true);
        }
        
        Assembly TestAssemblyMethod(MethodInfo methodInfo, Object[] parameters = null, Boolean shouldFail = false)
        {
            return (Assembly)InvokeMethod(methodInfo: methodInfo, parameters: parameters, shouldFail: shouldFail);
        }
        
        /// <summary>
        /// Assembly method should return an instance of an Assembly with a valid assembly name.
        /// </summary>
        [TestMethod]
        public void Assembly_method_should_return_an_Assembly()
        {
            var methodInfo = GetAssemblyMethod();
            var parameters = new String[] { "MGN.ReflectionTests" };
            TestAssemblyMethod(methodInfo: methodInfo, parameters: parameters, shouldFail: false);
        }

        static Object InvokeMethod(MethodInfo methodInfo, Object[] parameters, Boolean shouldFail = false)
        {
            object resultObject = null;
            Exception caughtException = null;
            try
            {
                resultObject = methodInfo.Invoke(obj: null, parameters: parameters);
            }
            catch (TargetInvocationException targetInvocationException)
            {
                caughtException = targetInvocationException;
            }
            if (shouldFail)
            {
                Assert.IsNotNull(value: caughtException, message: methodInfo.Name + "(" + String.Join<Object>(", ", parameters) + ") should throw an Exception.");
                var innerException = caughtException.InnerException ?? caughtException;
                Assert.IsInstanceOfType(
                    value: innerException,
                    expectedType: typeof(AssertFailedException),
                    message: methodInfo.Name + "(" + String.Join<Object>(", ", parameters) + ") should throw an AssertFailedException.");
            }
            if (!shouldFail)
            {
                Assert.IsNotNull(value: resultObject, message: methodInfo.Name + "(" + String.Join<Object>(", ", parameters) + ") should not be null.");
            }
            return resultObject;
        }
        /// <summary>
        /// Tests for the existance of the Class method.
        /// </summary>
        [TestMethod]
        public void Class_method_should_exist()
        {
            GetClassMethod();
        }

        static MethodInfo GetClassMethod()
        {
            var methodName = "Class";
            var parameterTypes = new Type[] { typeof(String), typeof(String) };
            var returnType = typeof(Type);
            return GetMethod(methodName: methodName, parameterTypes: parameterTypes, returnType: returnType);
        }
    }
}