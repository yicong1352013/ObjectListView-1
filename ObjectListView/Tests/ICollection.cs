// ObjectListView
// Copyright � 2006-2015 Jesse Johnston.  All rights reserved.

#pragma warning disable 1591	// Missing XML comment

#if TEST
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JesseJohnston.Tests
{
	[TestClass]
	public class ICollectionTests
	{
		private List<SimpleClass> emptyList;
		private List<SimpleClass> nonEmptyList;

		[TestInitialize]
		public void Setup()
		{
			emptyList = new List<SimpleClass>();
			nonEmptyList = new List<SimpleClass>();
			nonEmptyList.Add(new SimpleClass(100, "aaa", new DateTime(1970, 1, 1)));
			nonEmptyList.Add(new SimpleClass(80, "bbb", new DateTime(1980, 12, 12)));
			nonEmptyList.Add(new SimpleClass(60, "ccc", new DateTime(1975, 6, 6)));
		}

		[TestMethod]
		public void CopyToEmptyList()
		{
			ObjectListView view = new ObjectListView(emptyList);
			SimpleClass[] array = new SimpleClass[0];
			view.CopyTo(array, 0);
		}

		[TestMethod]
		public void CountEmptyList()
		{
			ObjectListView view = new ObjectListView(emptyList);
			Assert.AreEqual(emptyList.Count, view.Count);
		}

		[TestMethod]
		public void IsSynchronizedEmptyList()
		{
			ObjectListView view = new ObjectListView(emptyList);
			Assert.AreEqual(((ICollection)emptyList).IsSynchronized, view.IsSynchronized);
		}

		[TestMethod]
		public void SyncRootEmptyList()
		{
			ObjectListView view = new ObjectListView(emptyList);
			Assert.AreEqual(((ICollection)emptyList).SyncRoot, view.SyncRoot);
		}

		[TestMethod]
		public void CopyTo()
		{
			ObjectListView view = new ObjectListView(nonEmptyList);
			SimpleClass[] array = new SimpleClass[3];
			view.CopyTo(array, 0);

			SimpleClass item = array[0];
			Assert.IsNotNull(item);
			Assert.AreEqual(100, item.IntegerValue);
			Assert.AreEqual("aaa", item.StringValue);
			Assert.AreEqual(new DateTime(1970, 1, 1), item.DateTimeValue);

			item = array[1];
			Assert.AreEqual(80, item.IntegerValue);
			Assert.AreEqual("bbb", item.StringValue);
			Assert.AreEqual(new DateTime(1980, 12, 12), item.DateTimeValue);

			item = array[2];
			Assert.AreEqual(60, item.IntegerValue);
			Assert.AreEqual("ccc", item.StringValue);
			Assert.AreEqual(new DateTime(1975, 6, 6), item.DateTimeValue);
		}

		[TestMethod]
		public void Count()
		{
			ObjectListView view = new ObjectListView(nonEmptyList);
			Assert.AreEqual(nonEmptyList.Count, view.Count);
		}

		[TestMethod]
		public void IsSynchronized()
		{
			ObjectListView view = new ObjectListView(nonEmptyList);
			Assert.AreEqual(((ICollection)nonEmptyList).IsSynchronized, view.IsSynchronized);
		}

		[TestMethod]
		public void SyncRoot()
		{
			ObjectListView view = new ObjectListView(nonEmptyList);
			Assert.AreEqual(((ICollection)nonEmptyList).SyncRoot, view.SyncRoot);
		}
	}
}
#endif
