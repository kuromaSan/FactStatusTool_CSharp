using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FactStatusTool.Scripts.Variable
{
 /// <summary>
 /// ランタイム用の ID 索引（一次ソースとして扱う想定）
 /// 内容は既存の DTO オブジェクト（SubjectConfig 等）をそのまま保持する。
 /// ※ 現状 DTO が IParentConfig を実装していないため object として扱う。
 /// </summary>
 public class FactStatusRegistry
 {
 private readonly Dictionary<string, object> _idIndex = new(StringComparer.Ordinal);
 private readonly object _lock = new();

 /// <summary>
 /// 読み取り専用の索引参照
 /// </summary>
 public IReadOnlyDictionary<string, object> IdIndex => _idIndex;

 public FactStatusRegistry()
 {
 }

 public void Clear()
 {
 lock (_lock)
 {
 _idIndex.Clear();
 }
 }

 public void LoadFrom(FactStatusConfig config)
 {
 if (config == null) throw new ArgumentNullException(nameof(config));

 lock (_lock)
 {
 _idIndex.Clear();

 AddRange(config.SubjectConfigList);
 AddRange(config.TodoConfigList);
 AddRange(config.EvidenceConfigList);
 AddRange(config.ResultConfigList);
 AddRange(config.ArgumentConfigList);
 AddRange(config.RecordConfigList);
 AddRange(config.ProcessConfigList);
 AddRange(config.StepConfigList);
 AddRange(config.SchemaConfigList);
 }
 }

 private void AddRange<T>(IEnumerable<T>? items)
 {
 if (items == null) return;

 foreach (var item in items)
 {
 Add(item!);
 }
 }

 public void Add(object item)
 {
 if (item == null) throw new ArgumentNullException(nameof(item));

 var id = GetId(item);
 if (string.IsNullOrEmpty(id)) throw new ArgumentException("item does not contain an Id property or Id is empty");

 lock (_lock)
 {
 _idIndex[id] = item;
 }
 }

 public bool Update(object item)
 {
 if (item == null) throw new ArgumentNullException(nameof(item));

 var id = GetId(item);
 if (string.IsNullOrEmpty(id)) return false;

 lock (_lock)
 {
 if (!_idIndex.ContainsKey(id)) return false;
 _idIndex[id] = item;
 return true;
 }
 }

 public bool Remove(string id)
 {
 if (string.IsNullOrEmpty(id)) return false;

 lock (_lock)
 {
 return _idIndex.Remove(id);
 }
 }

 public bool TryGet<T>(string id, out T? item) where T : class
 {
 item = null;
 if (string.IsNullOrEmpty(id)) return false;

 lock (_lock)
 {
 if (_idIndex.TryGetValue(id, out var obj) && obj is T t)
 {
 item = t;
 return true;
 }

 return false;
 }
 }

 public bool TryGet(string id, out object? item)
 {
 item = null;
 if (string.IsNullOrEmpty(id)) return false;

 lock (_lock)
 {
 return _idIndex.TryGetValue(id, out item);
 }
 }

 internal static string GetId(object item)
 {
 if (item == null) return string.Empty;
 var pi = item.GetType().GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
 if (pi != null)
 {
 var v = pi.GetValue(item);
 return v?.ToString() ?? string.Empty;
 }

 // fallback: PathName
 var pn = item.GetType().GetProperty("PathName", BindingFlags.Public | BindingFlags.Instance);
 if (pn != null)
 {
 var v = pn.GetValue(item);
 return v?.ToString() ?? string.Empty;
 }

 return string.Empty;
 }

 internal static string GetParentId(object item)
 {
 if (item == null) return string.Empty;
 var pi = item.GetType().GetProperty("ParentId", BindingFlags.Public | BindingFlags.Instance);
 if (pi != null)
 {
 var v = pi.GetValue(item);
 return v?.ToString() ?? string.Empty;
 }

 return string.Empty;
 }
 }
}
