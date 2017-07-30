//
// CrashlyticsImplementation.cs (iOS)
// Crashlytics
//
// Created by David N. Junod on 7/30/2017
// Copyright (c) 2017 Reality Check, Inc.  All Rights Reserved Worldwide.
//
using System;
namespace CrashlyticsKit
{
	public class CrashlyticsImplementation : ICrashlytics
	{
		public CrashlyticsImplementation()
		{
			Console.WriteLine("Crashlytics initialized (iOS)");
		}

		public string Version {
			get {
				throw new NotImplementedException();
			}
		}

		public void Crash()
		{
			throw new NotImplementedException();
		}

		public ICrashlytics Log(string msg)
		{
			throw new NotImplementedException();
		}

		public void RecordException(Exception exception)
		{
			throw new NotImplementedException();
		}

		public ICrashlytics SetBoolValue(string key, bool value)
		{
			throw new NotImplementedException();
		}

		public ICrashlytics SetDoubleValue(string key, double value)
		{
			throw new NotImplementedException();
		}

		public ICrashlytics SetFloatValue(string key, float value)
		{
			throw new NotImplementedException();
		}

		public ICrashlytics SetIntValue(string key, int value)
		{
			throw new NotImplementedException();
		}

		public ICrashlytics SetLongValue(string key, long value)
		{
			throw new NotImplementedException();
		}

		public ICrashlytics SetObjectValue(string key, object value)
		{
			throw new NotImplementedException();
		}

		public ICrashlytics SetStringValue(string key, string value)
		{
			throw new NotImplementedException();
		}

		public ICrashlytics SetUserEmail(string email)
		{
			throw new NotImplementedException();
		}

		public ICrashlytics SetUserIdentifier(string identifier)
		{
			throw new NotImplementedException();
		}

		public ICrashlytics SetUserName(string name)
		{
			throw new NotImplementedException();
		}
	}
}
