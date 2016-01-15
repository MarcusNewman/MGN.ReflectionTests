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
                var assemblyFileNameAndPath = "..\\..\\..\\bin\\Debug\\" + AssemblyName + ".dll";
                assembly = Assembly.LoadFrom(assemblyFile: assemblyFileNameAndPath);
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

        static MethodBase GetAssemblyMethod()
        {
            var methodName = "Assembly";
            var parameterTypes = new Type[] { typeof(String) };
            var returnType = typeof(Assembly);
            return GetMethod(methodName: methodName, parameterTypes: parameterTypes, returnType: returnType);
        }

        static MethodBase GetMethod(string methodName, Type[] parameterTypes, Type returnType)
        {
            var classtype = GetClasstype();
            var method = classtype.GetMethod(name: methodName);
            var methodParameters = method.GetParameters();
            Assert.IsTrue(condition: methodParameters.Length == parameterTypes.Length, message: methodName + " method should accept " + parameterTypes.Length + " parameter(s).");
            for (var i = 0; i < methodParameters.Length; i++)
            {
                Assert.IsTrue(condition: methodParameters[i].ParameterType == parameterTypes[i], message: methodName + " parameter " + i.ToString() + " should be of type " + parameterTypes[i].ToString() + ".");
            }
            //Assert.IsTrue(condition: methodInfo.IsStatic, message: methodName + " method should be static.");
            Assert.IsTrue(condition: method.ReturnType == returnType, message: methodName + " method return type should be " + returnType.ToString() + ".");
            return method;
        }

        /// <summary>
        /// Assembly method should fail with an invalid assembly name.
        /// </summary>
        [TestMethod]
        public void Assembly_method_should_fail_with_an_invalid_assembly_name()
        {
            var method = GetAssemblyMethod();
            var parameters = new String[] { "InvalidAssemblyName" };
            TestAssemblyMethod(methodBase: method, parameters: parameters, shouldFail: true);
        }

        Assembly TestAssemblyMethod(MethodBase methodBase, Object[] parameters = null, Boolean shouldFail = false)
        {
            return (Assembly)InvokeMethod(methodBase: methodBase, parameters: parameters, shouldFail: shouldFail);
        }

        /// <summary>
        /// Assembly method should return an instance of an Assembly with a valid assembly name.
        /// </summary>
        [TestMethod]
        public void Assembly_method_should_return_an_Assembly()
        {
            var methodInfo = GetAssemblyMethod();
            var parameters = new String[] { AssemblyName };
            TestAssemblyMethod(methodBase: methodInfo, parameters: parameters, shouldFail: false);
        }

        static Object InvokeMethod(MethodBase methodBase, Object[] parameters, Boolean shouldFail = false)
        {
            object resultObject = null;
            Exception caughtException = null;
            try
            {
                resultObject = methodBase.Invoke(obj: null, parameters: parameters);
            }
            catch (TargetInvocationException targetInvocationException)
            {
                caughtException = targetInvocationException;
            }
            if (shouldFail)
            {
                Assert.IsNotNull(value: caughtException, message: methodBase.Name + "(" + String.Join<Object>(", ", parameters) + ") should throw an Exception.");
                var innerException = caughtException.InnerException ?? caughtException;
                Assert.IsInstanceOfType(
                    value: innerException,
                    expectedType: typeof(AssertFailedException),
                    message: methodBase.Name + "(" + String.Join<Object>(", ", parameters) + ") should throw an AssertFailedException.");
            }
            if (!shouldFail)
            {
                Assert.IsNotNull(value: resultObject, message: methodBase.Name + "(" + String.Join<Object>(", ", parameters) + ") should not be null.");
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

        static MethodBase GetClassMethod()
        {
            var methodName = "Class";
            var parameterTypes = new Type[] { typeof(String), typeof(String) };
            var returnType = typeof(Type);
            return GetMethod(methodName: methodName, parameterTypes: parameterTypes, returnType: returnType);
        }

        /// <summary>
        /// Class method should fail with an invalid class name.
        /// </summary>
        [TestMethod]
        public void Class_method_should_fail_with_an_invalid_class_name()
        {
            var methodBase = GetClassMethod();
            var parameters = new String[] { AssemblyName, "InvalidClassName" };
            TestClassMethod(methodBase: methodBase, parameters: parameters, shouldFail: true);
        }

        Type TestClassMethod(MethodBase methodBase, Object[] parameters = null, Boolean shouldFail = false)
        {
            return (Type)InvokeMethod(methodBase: methodBase, parameters: parameters, shouldFail: shouldFail);
        }

        /// <summary>
        /// Class method should return an instance of a Type with a valid class name.
        /// </summary>
        [TestMethod]
        public void Class_method_should_return_a_Type()
        {
            var methodInfo = GetClassMethod();
            var parameters = new String[] { AssemblyName, "ReflectionTest" };
            TestClassMethod(methodBase: methodInfo, parameters: parameters, shouldFail: false);
        }

        /// <summary>
        /// Tests for the existance of the Method method.
        /// </summary>
        [TestMethod]
        public void Method_method_should_exist()
        {
            GetMethod();
        }

        private MethodBase GetMethod()
        {
            var methodName = "Method";
            var parameterTypes = new Type[] { typeof(String), typeof(String), typeof(String) };
            var returnType = typeof(MethodBase);
            return GetMethod(methodName: methodName, parameterTypes: parameterTypes, returnType: returnType);
        }

        /// <summary>
        /// Method should fail with an invalid method name.
        /// </summary>
        [TestMethod]
        public void Method_method_should_fail_with_an_invalid_method_name()
        {
            var methodBase = GetMethod();
            var parameters = new String[] { AssemblyName, "ReflectionTest", "InvalidMethodName" };
            TestMethodMethod(methodBase: methodBase, parameters: parameters, shouldFail: true);
        }

        MethodBase TestMethodMethod(MethodBase methodBase, Object[] parameters = null, Boolean shouldFail = false)
        {
            return (MethodBase)InvokeMethod(methodBase: methodBase, parameters: parameters, shouldFail: shouldFail);
        }

        /// <summary>
        /// Method should return a methodBase with a valid method name.
        /// </summary>
        [TestMethod]
        public void Method_should_return_a_methodBase()
        {
            var methodBase = GetMethod();
            var parameters = new String[] { AssemblyName, "ReflectionTest", "Assembly" };
            TestMethodMethod(methodBase: methodBase, parameters: parameters, shouldFail: false);
        }

        /// <summary>
        /// Method should return a methodBase with a valid constructor name.
        /// </summary>
        [TestMethod]
        public void Method_should_return_a_methodBase_constructor()
        {
            var methodBase = GetMethod();
            var parameters = new String[] { AssemblyName, "ReflectionTest", "ReflectionTest" };
            TestMethodMethod(methodBase: methodBase, parameters: parameters, shouldFail: false);
        }

    }
}