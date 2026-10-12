using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Internal.Rule;

namespace FactStatus.Domain.Internal.Value {
    /// <summary>
    /// 結果表明クラス
    /// </summary>
    public class AssertionValue {
        // プロパティ
        public IdValue Id { get; }
        public IdValue ParentId { get; }
        public AssertEnum Assert { get; private set; }
        public string Target { get; private set; }
        public DataTypeEnum DataType { get; private set; }
        public string Value { get; private set; }

        /// <summary>
        /// 初期作成
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static AssertionValue Create(
            IdValue id,
            IdValue parentId) {

            return new AssertionValue(
                id,
                parentId,
                AssertEnum.None,
                "",
                DataTypeEnum.None,
                "");
        }

        /// <summary>
        /// ビルド
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentId"></param>
        /// <param name="assert"></param>
        /// <param name="target"></param>
        /// <param name="dataType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AssertionValue Build(
            IdValue id,
            IdValue parentId,
            AssertEnum assert,
            string target,
            DataTypeEnum dataType,
            string value) {
            return new AssertionValue(
                id,
                parentId,
                assert,
                target,
                dataType,
                value);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentId"></param>
        /// <param name="assert"></param>
        /// <param name="target"></param>
        /// <param name="dataType"></param>
        /// <param name="value"></param>
        public AssertionValue(
            IdValue id,
            IdValue parentId,
            AssertEnum assert,
            string target,
            DataTypeEnum dataType,
            string value) {

            Id = id;
            ParentId = parentId;
            Assert = assert;

            Validation.NullOfString(target);
            Target = target;
            
            DataType = dataType;
            
            Value = value ?? "";
        }
    }
}
