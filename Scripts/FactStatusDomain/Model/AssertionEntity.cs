using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactStatus.Domain.Rule;
using FactStatus.Domain.Value;

namespace FactStatus.Domain.Model {
    /// <summary>
    /// 結果表明クラス
    /// </summary>
    public class AssertionEntity {
        // プロパティ
        public IdValue Id { get; }
        public IdValue ParentId { get; }
        public AssertEnum Assert { get; private set; }
        public string Target { get; private set; }
        public DataTypeEnum DataType { get; private set; }
        public string Value { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parentId"></param>
        /// <param name="assert"></param>
        /// <param name="target"></param>
        /// <param name="dataType"></param>
        /// <param name="value"></param>
        public AssertionEntity(
            IdValue id,
            IdValue parentId,
            AssertEnum assert,
            string target,
            DataTypeEnum dataType,
            string value) {

            Id = id;
            ParentId = parentId;

            Validation.EnumNotNullAndDefined<AssertEnum>(assert,AssertEnum.None);
            Assert = assert;

            Validation.NullOfString(target);
            Target = target;
            
            Validation.EnumNotNullAndDefined<DataTypeEnum>(dataType, DataTypeEnum.None);
            DataType = dataType;
            
            Value = value ?? "";
        }
    }
}
