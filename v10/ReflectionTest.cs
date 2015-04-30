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
            var relativeAssemblyPath = String.Format("..\\..\\..\\..\\{0}\\bin\\Debug\\{0}.dll", assemblyName);
            //..\\..\\..\\{0}\\bin\\Debug\\{0}.dll", assemblyName);
            //"..\\..\\..\\bin\\Debug\\{0}.dll", assemblyName);

            try
            {
                return System.Reflection.Assembly.LoadFrom(relativeAssemblyPath);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                throw new AssertFailedException(assemblyName + " assembly was not found.", fileNotFoundException);
            }
        }
        /*
       /// <summary>
       /// Tests for the existance of a class type using reflection.
       /// </summary>
       /// <param name="assemblyName">Name of the assembly.</param>
       /// <param name="className">Name of the class.</param>
       /// <returns>The Type of the class.</returns>
       /// <exception cref="Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown when the assembly or class is not found.</exception>
       public static Type Class(String assemblyName, String className)
       {
           var assembly = Assembly.Test(assemblyName: assemblyName);
           try { return assembly.GetType(assembly.GetName().Name + "." + className, true); }
           catch (TypeLoadException typeLoadException)
           { throw new Exception(className + " class was not found.", typeLoadException); }
       }

       /// <summary>
       /// Tests for the existance of a method using reflection.
       /// </summary>
       /// <param name="assemblyName">Name of the assembly.</param>
       /// <param name="className">Name of the class.</param>
       /// <param name="methodName">Name of the method.</param> 
       /// <returns>The MethodInfo of the method.</returns>
       /// <exception cref="Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException">Thrown when the assembly, class or method is not found.</exception>
       public static r.MethodInfo Method(String assemblyName, String className, String methodName)
       {
           var classType = Class(assemblyName: assemblyName, className: className);
           var methodInfo = classType.GetMethod(name: methodName);
           if (methodInfo == null) throw new Exception(methodName + " method was not found.");
           return methodInfo;
       }
    */
    }
}

