using System;
 using System.Data;
 using System.Reflection;
 using System.Reflection.Emit;
 namespace ConsoleApplicationReflection
 {
     class MathClassBuilder
     {
         /**//// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Ma1in(string[] args)
        {
            try
            {
                Console.WriteLine("Enter values:");
                string numbers = Console.ReadLine();
                string[] values = numbers.Split(',');

                Type MathOpsClass = CreateType("OurAssembly","OurModule", "MathOps", "ReturnSum", values);

                object  MathOpsInst = Activator.CreateInstance(MathOpsClass);

                object obj = MathOpsClass.InvokeMember("ReturnSum",BindingFlags.InvokeMethod,null,MathOpsInst,null);

                Console.WriteLine("Sum: {0}",obj.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured: {0}",ex.Message);
            }


            Console.ReadLine();
        }
        
        public static Type CreateType(string assemblyName,string moduleName,string className,string methodName,string[] values)
        {
            try
            {
                AssemblyName name = new AssemblyName();
                name.Name = assemblyName;

                AppDomain domain = System.Threading.Thread.GetDomain();

                AssemblyBuilder assBuilder = domain.DefineDynamicAssembly(name,AssemblyBuilderAccess.Run);

                ModuleBuilder mb = assBuilder.DefineDynamicModule(moduleName);

                TypeBuilder theClass = mb.DefineType(className,TypeAttributes.Public & TypeAttributes.Class);
            
                Type rtnType = typeof(int);
            
                MethodBuilder method = theClass.DefineMethod(methodName,MethodAttributes.Public,rtnType,null);

                ILGenerator gen = method.GetILGenerator();

                gen.Emit(OpCodes.Ldc_I4,0);

                for(int i=0;i<values.Length;i++)
                {
                    gen.Emit(OpCodes.Ldc_I4,int.Parse(values[i]));
                    gen.Emit(OpCodes.Add);
                }
                gen.Emit(OpCodes.Ret);

                return theClass.CreateType();
            }
            catch(Exception ex)
            {
                Console.WriteLine("An error occured: {0}",ex.Message);
                return null;
            }
        }
        
    }
}
