using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuaInterpreter
{
	class Worker
	{
		private IProgress<bool> progress_mass;
		private Thread t_work;
		private List<string> out_list;

		private ListBox listb;

		public Worker(ref ListBox lb)
		{
			listb = lb;
			out_list = new List<string>();

			Script.DefaultOptions.DebugPrint = s =>
			{
				out_list.Add(s);
			};

			progress_mass = new Progress<bool>(StatusBar =>
			{
				listb.Items.AddRange(out_list.ToArray());
				listb.TopIndex = listb.Items.Count - 1;

				out_list.Clear();
			});
		}

		public async void doScript(string code, int timeout)
		{
			Task task = runScript(code);
			if (task == await Task.WhenAny(task, Task.Delay(timeout)))
			{
				await task;
			}
			else
			{
				abortScript();
			}
		}

		public async void doScript(string code)
		{
			await runScript(code);
		}

		private Task runScript(string code)
		{
			out_list.Clear();

			return Task.Run(() =>
			{
				Stopwatch sw = new Stopwatch();
				t_work = Thread.CurrentThread;

				try
				{
					sw.Start();
					DynValue res = Script.RunString(code);
					if (res.Type != DataType.Void)
						out_list.Add("Return value : " + res.ToString());
				}
				catch (InterpreterException ex)
				{
					out_list.Add(ex.DecoratedMessage);
				}
				catch (Exception ex)
				{
					out_list.Add(ex.Message);
				}
				finally
				{
					sw.Stop();
					out_list.Add("Script completed in : " + sw.ElapsedMilliseconds + "ms");
					progress_mass.Report(true);
				}
			});
		}

		private void abortScript()
		{
			t_work.Abort();
		}
	}
}
