using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace FactStatusTool.Scripts.Variable
{
 /// <summary>
 /// UIバインド向けの ObservableCollection ラッパー
 /// 実際の型は object を用いるが、必要ならジェネリック化する
 /// </summary>
 public class FactStatusCollection : ObservableCollection<object>
 {
 public FactStatusCollection()
 {
 }

 public void LoadFromRegistry(FactStatusRegistry registry)
 {
 if (registry == null) throw new ArgumentNullException(nameof(registry));
 this.Clear();
 foreach (var kv in registry.IdIndex)
 {
 this.Add(kv.Value);
 }
 }
 }
}
