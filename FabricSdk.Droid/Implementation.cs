//
// Implementation.cs (Android)
// Fabric Crashlytics NuGet Package
//
// Created by David N. Junod on 7/31/2017
// Copyright 2017 Reality Check, Inc. All Rights Reserved Worldwide.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

using Android.Content;

namespace FabricSdk
{
	public class Kit : IKit
	{
		internal Bindings.FabricSdk.Kit NativeKit;

		public Kit(Bindings.FabricSdk.Kit nativeKit)
		{
			NativeKit = nativeKit;
		}

		public string Version
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}

	public static class KitMixins
	{
		public static Bindings.FabricSdk.Kit ToNative(this IKit kit)
		{
			return (kit as Kit)?.NativeKit;
		}
	}

    public sealed class FabricImplementation : IFabric
	{
        Context _context;
		bool _debug = false;
		ICollection<IKit> _kits = new List<IKit>();

		public FabricImplementation()
		{
			Console.WriteLine("Fabric initialization (Android)");

			// Don't ever remove this. This shows what methods are available. */
            /*
			Assembly asm = Assembly.GetExecutingAssembly();
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("Android Assembly Path: {0}", Path.GetDirectoryName(asm.Location));
			sb.AppendLine();
			sb.AppendFormat("Android Assembly: {0}", asm.FullName);
			sb.AppendLine();
			foreach (Type type in asm.GetTypes())
			{
				if (type.Namespace == "Bindings.FabricSdk")
				{
					sb.AppendFormat("  {0}.{1}", type.Namespace, type.Name);
					sb.AppendLine();
					foreach (MethodInfo method in type.GetMethods())
					{
						ParameterInfo[] pars = method.GetParameters();
						sb.AppendFormat("    {0} {1}(", method.ReturnType.Name, method.Name);
						if ((pars != null) && (pars.Length > 0))
						{
							int i = 0;
							foreach (ParameterInfo par in pars)
							{
								if (i > 0)
									sb.Append(",");
								sb.AppendFormat("{0} {1}", par.ParameterType.Name, par.Name);
								i++;
							}
						}
						sb.AppendLine(");");
					}
				}
			}
			Console.WriteLine(sb.ToString());
			 */
		}

        public Context Context {
            set {
                _context = value;
            }
        }

		public string AppIdentifier
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public string AppInstallIdentifier
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool Debug
		{
			get
			{
				return _debug;
			}

			set
			{
				_debug = value;
			}
		}

		public string Identifier
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICollection<IKit> Kits
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public string Version
		{
			get
			{
				throw new NotImplementedException();
			}
		}

        public void With(ICollection<IKit> Kits)
        {
            var nativeKits = new List<Bindings.FabricSdk.Kit>();
			foreach (var kit in Kits)
				nativeKits.Add(kit.ToNative());
			Bindings.FabricSdk.Fabric.With(_context, nativeKits.ToArray());
		}
    }
}
