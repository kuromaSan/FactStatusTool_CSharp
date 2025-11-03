using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactStatusTool.Scripts.Variable {

    /// <summary>
    /// コアな情報をまとめたクラス
    /// </summary>
    /// <param name="subjectConfigs"></param>
    /// <param name="todoConfigs"></param>
    /// <param name="evidenceConfigs"></param>
    /// <param name="resultConfigs"></param>
    /// <param name="argumentConfigs"></param>
    /// <param name="recordConfigs"></param>
    /// <param name="processConfigs"></param>
    /// <param name="stepConfigs"></param>
    /// <param name="schemaConfigs"></param>
    public class FactStatusConfig(
        List<SubjectConfig> subjectConfigs,
        List<TodoConfig> todoConfigs,
        List<EvidenceConfig> evidenceConfigs,
        List<ResultConfig> resultConfigs,
        List<ArgumentConfig> argumentConfigs,
        List<RecordConfig> recordConfigs,
        List<ProcessConfig> processConfigs,
        List<StepConfig> stepConfigs,
        List<SchemaConfig> schemaConfigs) {
        public List<SubjectConfig> SubjectConfigList {
            get {
                return subjectConfigs;
            }
            internal set {
                subjectConfigs = value;
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

        public List<RecordConfig> RecordConfigList {
            get {
                return recordConfigs;
            }
            internal set {
                recordConfigs = value;
            }
        }

        public List<ProcessConfig> ProcessConfigList {
            get {
                return processConfigs;
            }
            internal set {
                processConfigs = value;
            }
        }

        public List<StepConfig> StepConfigList {
            get {
                return stepConfigs;
            }
            internal set {
                stepConfigs = value;
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

    interface IParentConfig {
        public string ParentId { get; set; }
        public string Id { get; set; }
        public string PathName { get; set; }
        public string Title { get; set; }
    }

    /// <summary>
    /// 主題に関するクラス
    /// </summary>
    /// <remarks>
    /// コンストラクタ
    /// </remarks>
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
            internal set {
                id = value;
            }
        }

        public string PathName {
            get {
                return pathName;
            }
            internal set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            internal set {
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
    /// 実装に関するクラス
    /// </summary>
    /// <remarks>
    /// コンストラクタ
    /// </remarks>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="pathName"></param>
    /// <param name="title"></param>
    /// <param name="description"></param>
    public class TodoConfig(
        string parentId,
        string id,
        string pathName,
        string title,
        string description) {
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

        public string PathName {
            get {
                return pathName;
            }
            internal set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            internal set {
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
    /// 証拠に関するクラス
    /// </summary>
    /// <remarks>
    /// コンストラクタ
    /// </remarks>
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
        string description) {
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

        public string PathName {
            get {
                return pathName;
            }
            internal set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            internal set {
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
    /// 
    /// </summary>
    /// <remarks>
    /// コンストラクタ
    /// </remarks>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="pathName"></param>
    /// <param name="title"></param>
    /// <param name="success"></param>
    /// <param name="expectedValue"></param>
    /// <param name="expectedType"></param>
    /// <param name="exceptionType"></param>
    public class ResultConfig(
        string parentId,
        string id,
        string pathName,
        string title,
        bool success,
        string expectedValue,
        string expectedType,
        string exceptionType) {
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

        public string PathName {
            get {
                return pathName;
            }
            internal set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            internal set {
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

        public string ExpectedValue {
            get {
                return expectedValue;
            }
            internal set {
                expectedValue = value;
            }
        }

        public string ExpectedType {
            get {
                return expectedType;
            }
            internal set {
                expectedType = value;
            }
        }

        public string ExceptionType {
            get {
                return exceptionType;
            }
            internal set {
                exceptionType = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// コンストラクタ
    /// </remarks>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="date"></param>
    /// <param name="reviewer"></param>
    /// <param name="success"></param>
    /// <param name="expectedValue"></param>
    /// <param name="expectedType"></param>
    /// <param name="exceptionType"></param>
    /// <param name="message"></param>
    public class RecordConfig(
        string parentId,
        string id,
        string pathName,
        string title,
        DateTime date,
        string reviewer,
        bool success,
        string expectedValue,
        string expectedType,
        string exceptionType,
        string message) {
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

        public string PathName {
            get {
                return pathName;
            }
            internal set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            internal set {
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

        public string ExpectedValue {
            get {
                return expectedValue;
            }
            internal set {
                expectedValue = value;
            }
        }

        public string ExpectedType {
            get {
                return expectedType;
            }
            internal set {
                expectedType = value;
            }
        }

        public string ExceptionType {
            get {
                return exceptionType;
            }
            internal set {
                exceptionType = value;
            }
        }

        public string Message {
            get {
                return message;
            }
            internal set {
                message = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// コンストラクタ
    /// </remarks>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="pathName"></param>
    /// <param name="title"></param>
    public class ProcessConfig(
        string parentId,
        string id,
        string pathName,
        string title) {
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

        public string PathName {
            get {
                return pathName;
            }
            internal set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            internal set {
                title = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// コンストラクタ
    /// </remarks>
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
        string abstractGoal,
        string executionGoal) {
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

        public string PathName {
            get {
                return pathName;
            }
            internal set {
                pathName = value;
            }
        }

        public string Title {
            get {
                return title;
            }
            internal set {
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

        public string AbstractGoal {
            get {
                return abstractGoal;
            }
            internal set {
                abstractGoal = value;
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
    /// コンストラクタ
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
    /// 
    /// </summary>
    /// <remarks>
    /// コンストラクタ
    /// </remarks>
    /// <param name="parentId"></param>
    /// <param name="id"></param>
    /// <param name="value"></param>
    public class StepConfig(
        string parentId,
        string id,
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
