using System;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.CSharp;
using UnityEngine;

namespace Radical.KerbalApiServer
{
    public class CodeCompiler : MonoBehaviour
    {
        void Start()
        {
            EvalInit();
        }


        private void EvalInit()
        {
            
            Debug.Log("Addon CodeCOmpiler init start");
            
            Evaluator.Init(new string[] {});
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                //Dbg.Log("refer: {0}", assembly.FullName);
                if (assembly.FullName.Contains("Cecil") || assembly.FullName.Contains("UnityEditor"))
                    continue;
                Evaluator.ReferenceAssembly(assembly);
            }
            Debug.Log("get using" + Evaluator.GetUsing());
            var init = Evaluator.Run("using UnityEngine;\n" +
                                     "using SwiftKSPRemote;\n" +
                                     "using SwiftKSPRemote.Api;\n" +
                                     "using SwiftKSPRemote.Attributes;\n" +
                                     "using SwiftKSPRemote;\n" +
                                     "using UnityEngine;\n" +
                                     "using Thrift;\n" +
                                     "using Thrift.Protocol;\n" +
                                     "using Thrift.Transport;\n" +
                                     "using Thrift.Collections;\n" +
                                     "using Thrift.Server;\n" +
                                     "using System;\n" +
                                     "using System.Collections;\n" +
                                     "using System.Collections.Generic;\n" +
                                     "using System.Reflection;\n"
                );
            Debug.Log("get using" + Evaluator.GetUsing());
            Debug.Log("Addon CodeCOmpiler init done: " + init);
        }




        public bool RunCode(string cmd)
        {
            EvalInit();
            try
            {
                Debug.Log("Going to evaluate run:");
                Debug.Log(cmd);
                return Evaluator.Run(cmd);
            }
            catch (Exception e)
            {
                LogExep(e);
                return false;
            }
        }

        public void CompileAndRun(string cmd)
        {
            EvalInit();
            try
            {
                Debug.Log("Going to compile and run:");
                Debug.Log(cmd);
                CompiledMethod compiledMethod;
                Evaluator.Compile(cmd, out compiledMethod);
                Debug.Log("Evaluator.Compiled");
                var retobj = new object();
                compiledMethod.Invoke(ref retobj);
                Debug.Log("method invoked, return:");
                Debug.Log(retobj.ToString());
            }
            catch (Exception e)
            {
                LogExep(e);
            }
        }

        protected void LogExep(Exception e)
        {
            Log("------------------exception-------------");
            Log(e.Message);
            Log(e.StackTrace);
            Log(e.ToString());
            foreach (var a in e.Data)
            {
                Log(a.ToString());
            }

            Log("------------------exception-end-------------");
        }

        protected void Log(string m)
        {
            GameObject.Find("SKRImmortal").GetComponent<Addon>().log(m);
            Addon.Log(m);
        }
    }
}