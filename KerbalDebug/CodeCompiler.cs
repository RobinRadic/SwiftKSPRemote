using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.CSharp;
using UnityEngine;

namespace Radical.KerbalDebug
{
    public class CodeCompiler : MonoBehaviour
    {

        void Start()
        {
            EvalInit();
        }


        private void EvalInit()
        {
            
            Debug.Log("SKR CodeCOmpiler init start");
            
            Evaluator.Init(new string[] {});
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    Debug.Log("refer: " + assembly.FullName);
                    if (assembly.FullName.Contains("Cecil") || assembly.FullName.Contains("UnityEditor"))
                        continue;
                    Evaluator.ReferenceAssembly(assembly);
                }
                catch (Exception e)
                {
                    LogExep(e);
                }
            }
            Debug.Log("get using" + Evaluator.GetUsing());
            var init = Evaluator.Run("using UnityEngine;\n" +
                                     "using Radical;\n" +
                                     "using Radical.KerbalApiServer;\n" +
                                     "using KerbalApi;\n" +
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
            Debug.Log("SKR CodeCOmpiler init done: " + init);
        }

        private static List<string> messagesToLog = new List<string>();

        private void Update()
        {
            try
            {
                foreach (var m in messagesToLog)
                {
                    Debug.LogWarning(m);
                }
                messagesToLog = new List<string>();
            }
            catch (Exception e)
            {
                Debug.LogWarning(e.Message + " ---- " + e.StackTrace);
            }
        }
        public static void Log(string m)
        {
            messagesToLog.Add(m);
        }

        public bool RunCode(string cmd)
        {

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

    }
}