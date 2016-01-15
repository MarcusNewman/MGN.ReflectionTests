using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MGN.ReflectionTests
{
    /// <summary>
    /// Unit test methods that use reflection.
    /// </summary>
    public static class ReflectionTest
    {
        //Todo: allow code to instatiaate this class so they don't have to keep calling get assembly,class method over and over
        // TODO: test this for internal vs external testing relative paths
        //TODO: just check both paths
        /// <summary>
        /// Tests for the existance of an assembly using reflection.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <returns>The assembly.</returns>
        /// <exception cref="Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown when the assembly is not found.</exception>
        public static Assembly Assembly(string assemblyName)
        {
            var currentDirectory = System.Environment.CurrentDirectory;
            var relativeAssemblyPath = String.Format("..\\..\\..\\bin\\Debug\\{0}.dll", assemblyName);
            //var relativeAssemblyPath = String.Format("..\\..\\..\\..\\{0}\\bin\\Debug\\{0}.dll", assemblyName);
            try
            {
                return System.Reflection.Assembly.LoadFrom(relativeAssemblyPath);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                throw new AssertFailedException(assemblyName + " assembly was not found.", fileNotFoundException);
            }
        }

        /// <summary>
        /// Tests for the existance of a class type using reflection.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns>The Type of the class.</returns>
        /// <exception cref="Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown when the class is not found.</exception>
        public static Type Class(String assemblyName, String className)
        {
            var assembly = Assembly(assemblyName: assemblyName);
            try { return assembly.GetType(assembly.GetName().Name + "." + className, true); }
            catch (TypeLoadException typeLoadException)//TODO: add test to check returned exception type is assertfail
            { throw new AssertFailedException(className + " class was not found.", typeLoadException); }
        }

        /// <summary>
        /// Tests for the existance of a method using reflection.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="methodName">Name of the method.</param> 
        /// <returns>The MethodInfo of the method.</returns>
        /// <exception cref="Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown when the method is not found.</exception>
        public static MethodInfo Method(String assemblyName, String className, String methodName)
        {
            var classType = Class(assemblyName: assemblyName, className: className);
            var methodInfo = classType.GetMethod(name: methodName);
            if (methodInfo == null)
                throw new AssertFailedException(methodName + " method was not found.");
            return methodInfo;
        }
    }
}

