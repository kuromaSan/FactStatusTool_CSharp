using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Setup {

    /// <summary>
    /// コアな情報をまとめたクラス
    /// </summary>
    /// <param name="subjectConfigs"></param>
    /// <param name="achievementConfigs"></param>
    /// <param name="evidenceConfigs"></param>
    /// <param name="resultConfigs"></param>
    /// <param name="argumentConfigs"></param>
    /// <param name="assertConfigs"></param>
    /// <param name="recordConfigs"></param>
    /// <param name="todoConfigs"></param>
    /// <param name="schemaConfigs"></param>
    public class FactStatusConfig(
        List<SubjectConfig> subjectConfigs,
        List<AchievementConfig> achievementConfigs,
        List<EvidenceConfig> evidenceConfigs,
        List<ResultConfig> resultConfigs,
        List<ArgumentConfig> argumentConfigs,
        List<AssertionConfig> assertConfigs,
        List<RecordConfig> recordConfigs,
        List<TodoConfig> todoConfigs,
        List<SchemaConfig> schemaConfigs) {
        public List<SubjectConfig> SubjectConfigList {
            get {
                return subjectConfigs;
            }
            internal set {
                subjectConfigs = value;
            }
        }

        public List<AchievementConfig> AchievementConfigList {
            get {
                return achievementConfigs;
            }
            internal set {
                achievementConfigs = value;
            }
        }

        public List<EvidenceConfig> EvidenceConfigList {
            get {
                return evidenceConfigs;
            }
            internal set {
                evidenceConfigs = value;
            }
        }

        public List<ResultConfig> ResultConfigList {
            get {
                return resultConfigs;
            }
            internal set {
                resultConfigs = value;
            }
        }

        public List<ArgumentConfig> ArgumentConfigList {
            get {
                return argumentConfigs;
            }
            internal set {
                argumentConfigs = value;
            }
        }

        public List<AssertionConfig> AssertionConfigList {
            get {
                return assertConfigs;
            }
            internal set {
                assertConfigs = value;
            }
        }

        public List<RecordConfig> RecordConfigList {
            get {
                return recordConfigs;
            }
            internal set {
                recordConfigs = value;
            }
        }

        public List<TodoConfig> TodoConfigList {
            get {
                return todoConfigs;
            }
            internal set {
                todoConfigs = value;
            }
        }

        public List<SchemaConfig> SchemaConfigList {
            get {
                return schemaConfigs;
            }
            internal set {
                schemaConfigs = value;
            }
        }
    }

    public interface IParentConfig {
        public string ParentId { get; internal set; }
        public string Id { get; internal set; }
        public string PathName { get; internal set; }
        public string Title { get; internal set; }
    }

    /// <summary>
    /// 主題設定クラス
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pathName"></param>
    /// <param name="title"></param>
    /// <param name="description"></param>
    public class SubjectConfig(
        string id,
        string pathName,
        string title,
        string description) {
        public string Id {
            get {
                return id;
            }
            set {
                id = value;
            }
        }

        public string PathName {
            get {
                return pathName;
            }
            set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            set {
                title = value;
            }
        }

        public string Description {
            get {
                return description;
            }
            set {
                description = value;
            }
        }
    }

    /// <summary>
    /// 達成設定クラス
    /// </summary>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="pathName"></param>
    /// <param name="title"></param>
    /// <param name="description"></param>
    public class AchievementConfig(
    string parentId,
    string id,
    string pathName,
    string title,
    string description) : IParentConfig {
        public string ParentId {
            get {
                return parentId;
            }
            set {
                parentId = value;
            }
        }

        public string Id {
            get {
                return id;
            }
            set {
                id = value;
            }
        }

        public string PathName {
            get {
                return pathName;
            }
            set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            set {
                title = value;
            }
        }

        public string Description {
            get {
                return description;
            }
            internal set {
                description = value;
            }
        }
    }

    /// <summary>
    /// 証拠設定クラス
    /// </summary>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="pathName"></param>
    /// <param name="title"></param>
    /// <param name="description"></param>
    public class EvidenceConfig(
        string parentId,
        string id,
        string pathName,
        string title,
        string description) : IParentConfig {
        public string ParentId {
            get {
                return parentId;
            }
            set {
                parentId = value;
            }
        }

        public string Id {
            get {
                return id;
            }
            set {
                id = value;
            }
        }

        public string PathName {
            get {
                return pathName;
            }
            set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            set {
                title = value;
            }
        }

        public string Description {
            get {
                return description;
            }
            internal set {
                description = value;
            }
        }
    }

    /// <summary>
    /// 結果設定クラス
    /// </summary>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="pathName"></param>
    /// <param name="title"></param>
    /// <param name="success"></param>
    public class ResultConfig(
        string parentId,
        string id,
        string pathName,
        string title,
        bool success) : IParentConfig {

        public string ParentId {
            get {
                return parentId;
            }
            set {
                parentId = value;
            }
        }

        public string Id {
            get {
                return id;
            }
            set {
                id = value;
            }
        }

        public string PathName {
            get {
                return pathName;
            }
            set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            set {
                title = value;
            }
        }

        public bool Success {
            get {
                return success;
            }
            internal set {
                success = value;
            }
        }
    }

    /// <summary>
    /// 記録設定クラス
    /// </summary>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="pathName"></param>
    /// <param name="title"></param>
    /// <param name="date"></param>
    /// <param name="reviewer"></param>
    /// <param name="success"></param>
    /// <param name="description"></param>
    public class RecordConfig(
        string parentId,
        string id,
        string pathName,
        string title,
        DateTime date,
        string reviewer,
        bool success,
        string description) : IParentConfig {

        public string ParentId {
            get {
                return parentId;
            }
            set {
                parentId = value;
            }
        }

        public string Id {
            get {
                return id;
            }
            set {
                id = value;
            }
        }

        public string PathName {
            get {
                return pathName;
            }
            set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            set {
                title = value;
            }
        }

        public DateTime Date {
            get {
                return date;
            }
            internal set {
                date = value;
            }
        }

        public string Reviewer {
            get {
                return reviewer;
            }
            internal set {
                reviewer = value;
            }
        }

        public bool Success {
            get {
                return success;
            }
            internal set {
                success = value;
            }
        }

        public string Description {
            get {
                return description;
            }
            internal set {
                description = value;
            }
        }
    }

    /// <summary>
    /// 実装設定クラス
    /// </summary>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="pathName"></param>
    /// <param name="title"></param>
    public class TodoConfig(
        string parentId,
        string id,
        string pathName,
        string title,
        string description) : IParentConfig {

        public string ParentId {
            get {
                return parentId;
            }
            set {
                parentId = value;
            }
        }

        public string Id {
            get {
                return id;
            }
            set {
                id = value;
            }
        }

        public string PathName {
            get {
                return pathName;
            }
            set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            set {
                title = value;
            }
        }
        
        public string Description {
            get {
                return description;
            }
            internal set {
                description = value;
            }
        }
    }

    /// <summary>
    /// 構想設定クラス
    /// </summary>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="pathName"></param>
    /// <param name="title"></param>
    /// <param name="experience"></param>
    /// <param name="evaluation"></param>
    /// <param name="hypothesis"></param>
    /// <param name="abstractGoal"></param>
    /// <param name="executionGoal"></param>
    public class SchemaConfig(
        string parentId,
        string id,
        string pathName,
        string title,
        string experience,
        string evaluation,
        string hypothesis,
        string abstractionGoal,
        string executionGoal) : IParentConfig {

        public string ParentId {
            get {
                return parentId;
            }
            set {
                parentId = value;
            }
        }

        public string Id {
            get {
                return id;
            }
            set {
                id = value;
            }
        }

        public string PathName {
            get {
                return pathName;
            }
            set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            set {
                title = value;
            }
        }

        public string Experience {
            get {
                return experience;
            }
            internal set {
                experience = value;
            }
        }

        public string Evaluation {
            get {
                return evaluation;
            }
            internal set {
                evaluation = value;
            }
        }

        public string Hypothesis {
            get {
                return hypothesis;
            }
            internal set {
                hypothesis = value;
            }
        }

        public string AbstractionGoal {
            get {
                return abstractionGoal;
            }
            internal set {
                abstractionGoal = value;
            }
        }

        public string ExecutionGoal {
            get {
                return executionGoal;
            }
            internal set {
                executionGoal = value;
            }
        }
    }

    /// <summary>
    /// 引数設定クラス
    /// </summary>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="key"></param>
    /// <param name="type"></param>
    /// <param name="value"></param>
    public class ArgumentConfig(
        string parentId,
        string id,
        string key,
        string type,
        string value) {

        public string ParentId {
            get {
                return parentId;
            }
            internal set {
                parentId = value;
            }
        }

        public string Id {
            get {
                return id;
            }
            internal set {
                id = value;
            }
        }

        public string Key {
            get {
                return key;
            }
            internal set {
                key = value;
            }
        }

        public string Type {
            get {
                return type;
            }
            internal set {
                type = value;
            }
        }

        private string _value = value;
        public string Value {
            get {
                return this._value;
            }
            internal set {
                this._value = value;
            }
        }
    }

    /// <summary>
    /// 表明設定クラス
    /// </summary>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="assert"></param>
    /// <param name="target"></param>
    /// <param name="type"></param>
    /// <param name="value"></param>
    public class AssertionConfig(
        string parentId,
        string id,
        string assert,
        string target,
        string type,
        string value) {
        public string ParentId {
            get {
                return parentId;
            }
            internal set {
                parentId = value;
            }
        }

        public string Id {
            get {
                return id;
            }
            internal set {
                id = value;
            }
        }

        private string _assert = assert;
        public string Assert {
            get {
                return this._assert;
            }
            internal set {
                this._assert = value;
            }
        }

        private string _target = target;
        public string Target {
            get {
                return this._target;
            }
            internal set {
                this._target = value;
            }
        }

        private string _type = type;
        public string Type {
            get {
                return this._type;
            }
            internal set {
                this._type = value;
            }
        }

        private string _value = value;
        public string Value {
            get {
                return this._value;
            }
            internal set {
                this._value = value;
            }
        }
    }
}
