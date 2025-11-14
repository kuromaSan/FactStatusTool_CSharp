using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace FactStatusTool.Scripts.Variable
{
 /// <summary>
 /// parentId -> children list ÇÃçıà¯Çï€éùÇ∑ÇÈÉNÉâÉX
 /// </summary>
 public class FactStatusHierarchy
 {
 private readonly Dictionary<string, List<object>> _children = new(StringComparer.Ordinal);
 private readonly object _lock = new();

 public IReadOnlyDictionary<string, List<object>> ChildrenIndex => _children;

 public FactStatusHierarchy()
 {
 }

 public void Clear()
 {
 lock (_lock)
 {
 _children.Clear();
 }
 }

 public void LoadFromRegistry(FactStatusRegistry registry)
 {
 if (registry == null) throw new ArgumentNullException(nameof(registry));

 lock (_lock)
 {
 _children.Clear();
 foreach (var kv in registry.IdIndex)
 {
 var item = kv.Value;
 var parentId = FactStatusRegistry.GetParentId(item) ?? string.Empty;
 if (!_children.TryGetValue(parentId, out var list))
 {
 list = new List<object>();
 _children[parentId] = list;
 }
 list.Add(item);
 }
 }
 }

 public void Add(object item)
 {
 if (item == null) throw new ArgumentNullException(nameof(item));
 var parentId = FactStatusRegistry.GetParentId(item) ?? string.Empty;

 lock (_lock)
 {
 if (!_children.TryGetValue(parentId, out var list))
 {
 list = new List<object>();
 _children[parentId] = list;
 }
 list.Add(item);
 }
 }

 public void Remove(object item)
 {
 if (item == null) return;
 var parentId = FactStatusRegistry.GetParentId(item) ?? string.Empty;

 lock (_lock)
 {
 if (_children.TryGetValue(parentId, out var list))
 {
 list.RemoveAll(x => ReferenceEquals(x, item) || FactStatusRegistry.GetId(x) == FactStatusRegistry.GetId(item));
 if (list.Count ==0) _children.Remove(parentId);
 }
 }
 }

 public IEnumerable<object> GetChildren(string parentId)
 {
 if (parentId == null) parentId = string.Empty;
 lock (_lock)
 {
 if (_children.TryGetValue(parentId, out var list))
 {
 return list.ToList();
 }
 return Enumerable.Empty<object>();
 }
 }
 }
}
