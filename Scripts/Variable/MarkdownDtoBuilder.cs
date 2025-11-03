using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static FactStatusTool.Scripts.Variable.MarkdownDto;

namespace FactStatusTool.Scripts.Variable {
    public class MarkdownDtoBuilder {
        private List<MarkdownItemDto> _markdownDtos;

        public MarkdownDtoBuilder OfFactStatusConfig(FactStatusConfig documentConfig) {
            // /Document/README.mdの生成
            MarkdownItemDto documentMarkdown = this.CreateDocumentMarkdown(
                documentConfig.SubjectConfigList,
                "Document/README.md");
            // リストに追加
            this._markdownDtos.Add(documentMarkdown);

            // /Subject/README.mdの生成
            foreach (SubjectConfig subjectConfig in documentConfig.SubjectConfigList) {
                // ファイルパスの生成
                string filePath = this.SearchFilePath(subjectConfig.Id,documentConfig);
                // マークダウンアイテムの生成
                MarkdownItemDto subjectMarkdown = this.CreateSubjectMarkdown(
                    subjectConfig,
                    documentConfig.TodoConfigList,
                    documentConfig.SchemaConfigList,
                    $"Document/{filePath}");
                // リストに追加
                this._markdownDtos.Add(subjectMarkdown);
            }

            // /Todo/README.mdの生成
            foreach (TodoConfig todoConfig in documentConfig.TodoConfigList) {
                // ファイルパスの生成
                string filePath = this.SearchFilePath(todoConfig.Id, documentConfig);
                // マークダウンアイテムの生成
                MarkdownItemDto todoMarkdown = this.CreateTodoMarkdown(
                    todoConfig,
                    documentConfig.EvidenceConfigList,
                    documentConfig.ProcessConfigList,
                    documentConfig.SchemaConfigList,
                    $"Document/{filePath}");
                // リストに追加
                this._markdownDtos.Add(todoMarkdown);
            }

            // /Evidence/README.mdの生成
            foreach (EvidenceConfig evidenceConfig in documentConfig.EvidenceConfigList) {
                // ファイルパスの生成
                string filePath = this.SearchFilePath(evidenceConfig.Id, documentConfig);
                // マークダウンアイテムの生成
                MarkdownItemDto evidenceMarkdown = this.CreateEvidenceMarkdown(
                    evidenceConfig,
                    documentConfig.ResultConfigList,
                    documentConfig.ProcessConfigList,
                    documentConfig.SchemaConfigList,
                    $"Document/{filePath}");
                // リストに追加
                this._markdownDtos.Add(evidenceMarkdown);
            }

            // /Result/README.mdの生成
            foreach (ResultConfig resultConfig in documentConfig.ResultConfigList) {
                // ファイルパスの生成
                string filePath = this.SearchFilePath(resultConfig.Id, documentConfig);
                // マークダウンアイテムの生成
                MarkdownItemDto resultMarkdown = this.CreateResultMarkdown(
                    resultConfig,
                    documentConfig.RecordConfigList,
                    documentConfig.ArgumentConfigList,
                    $"Document/{filePath}");
                // リストに追加
                this._markdownDtos.Add(resultMarkdown);
            }

            // /Record/README.mdの生成
            foreach (RecordConfig recordConfig in documentConfig.RecordConfigList) {
                // ファイルパスの生成
                string filePath = this.SearchFilePath(recordConfig.Id, documentConfig);
                // マークダウンアイテムの生成
                MarkdownItemDto recordMarkdown = this.CreateRecordMarkdown(
                    recordConfig,
                    $"Document/{filePath}");
                // リストに追加
                this._markdownDtos.Add(recordMarkdown);
            }

            // /Process/README.mdの生成
            foreach (ProcessConfig processConfig in documentConfig.ProcessConfigList) {
                // ファイルパスの生成
                string filePath = this.SearchFilePath(processConfig.Id, documentConfig);
                // マークダウンアイテムの生成
                MarkdownItemDto processMarkdown = this.CreateProcessMarkdown(
                    processConfig,
                    documentConfig.StepConfigList,
                    $"Document/{filePath}");
                // リストに追加
                this._markdownDtos.Add(processMarkdown);
            }

            // /Schema/README.mdの生成
            foreach (SchemaConfig schemaConfig in documentConfig.SchemaConfigList) {
                // ファイルパスの生成
                string filePath = this.SearchFilePath(schemaConfig.Id, documentConfig);
                // マークダウンアイテムの生成
                MarkdownItemDto schemaMarkdown = this.CreateSchemaMarkdown(
                    schemaConfig,
                    $"Document/{filePath}");
                // リストに追加
                this._markdownDtos.Add(schemaMarkdown);
            }
            return this;
        }

        public MarkdownDtoBuilder OfFactStatusConfig(FactStatusConfig documentConfig, string id) {
            // ファイルパスの生成
            string filePath = this.SearchFilePath(id, documentConfig);
            
            switch (id) {
                case "Document":
                    MarkdownItemDto documentMarkdown = this.CreateDocumentMarkdown(
                        documentConfig.SubjectConfigList,
                        "Document/README.md");
                    this._markdownDtos[0] = documentMarkdown;
                    break;
                case "Subject":
                    SubjectConfig subjectConfig = this.SearchSubjectConfig(id, documentConfig.SubjectConfigList);
                    MarkdownItemDto subjectMarkdown = this.CreateSubjectMarkdown(
                        subjectConfig,
                        documentConfig.TodoConfigList,
                        documentConfig.SchemaConfigList,
                        $"Document/{filePath}");
                    this._markdownDtos[0] = subjectMarkdown;
                    break;
                case "Todo":
                    TodoConfig todoConfig = this.SearchTodoConfig(id, documentConfig.TodoConfigList);
                    MarkdownItemDto todoMarkdown = this.CreateTodoMarkdown(
                        todoConfig,
                        documentConfig.EvidenceConfigList,
                        documentConfig.ProcessConfigList,
                        documentConfig.SchemaConfigList,
                        $"Document/{filePath}");
                    this._markdownDtos[0] = todoMarkdown;
                    break;
                case "Evidence":
                    EvidenceConfig evidenceConfig = this.SearchEvidenceConfig(id, documentConfig.EvidenceConfigList);
                    MarkdownItemDto evidenceMarkdown = this.CreateEvidenceMarkdown(
                        evidenceConfig,
                        documentConfig.ResultConfigList,
                        documentConfig.ProcessConfigList,
                        documentConfig.SchemaConfigList,
                        $"Document/{filePath}");
                    this._markdownDtos[0] = evidenceMarkdown;
                    break;
                case "Result":
                    ResultConfig resultConfig = this.SearchResultConfig(id, documentConfig.ResultConfigList);
                    MarkdownItemDto resultMarkdown = this.CreateResultMarkdown(
                        resultConfig,
                        documentConfig.RecordConfigList,
                        documentConfig.ArgumentConfigList,
                        $"Document/{filePath}");
                    this._markdownDtos[0] = resultMarkdown;
                    break;
                case "Record":
                    RecordConfig recordConfig = this.SearchRecordConfig(id, documentConfig.RecordConfigList);
                    MarkdownItemDto recordMarkdown = this.CreateRecordMarkdown(
                        recordConfig,
                        $"Document/{filePath}");
                    this._markdownDtos[0] = recordMarkdown;
                    break;
                case "Process":
                    ProcessConfig processConfig = this.SearchProcessConfig(id, documentConfig.ProcessConfigList);
                    MarkdownItemDto processMarkdown = this.CreateProcessMarkdown(
                        processConfig,
                        documentConfig.StepConfigList,
                        $"Document/{filePath}");
                    this._markdownDtos[0] = processMarkdown;
                    break;
                case "Schema":
                    SchemaConfig schemaConfig = this.SearchSchemaConfig(id, documentConfig.SchemaConfigList);
                    MarkdownItemDto schemaMarkdown = this.CreateSchemaMarkdown(
                        schemaConfig,
                        $"Document/{filePath}");
                    this._markdownDtos[0] = schemaMarkdown;
                    break;
            }
            return this;
        }

        /// <summary>
        /// MarkdownDtoの生成
        /// </summary>
        /// <returns></returns>
        public MarkdownItemDto Build() {
            return new MarkdownItemDto {
                Directory = this._markdownDtos[0].Directory,
                Description = this._markdownDtos[0].Description
            };
        }

        /// <summary>
        /// MarkdownListDtoの生成
        /// </summary>
        /// <returns></returns>
        public MarkdownDto ListBuild() {
            return new MarkdownDto {
                MarkdownItemDtoList = this._markdownDtos,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="documentConfig"></param>
        /// <returns></returns>
        private string SearchFilePath(string id, FactStatusConfig documentConfig) {
            string classTypeId = id.Substring(id.Length - 2);
            // idに紐づくデータを抽出
            switch(classTypeId) {
                case "01":
                    var subject = documentConfig.SubjectConfigList?.FirstOrDefault(subject => subject.Id == id);
                    return this.BuildPath(subject, documentConfig);
                case "02":
                    var todo = documentConfig.TodoConfigList?.FirstOrDefault(todo => todo.Id == id);
                    return this.BuildPath(todo, documentConfig);
                case "03":
                    var evidence = documentConfig.EvidenceConfigList?.FirstOrDefault(evidence => evidence.Id == id);
                    return this.BuildPath(evidence, documentConfig);
                case "04":
                    var result = documentConfig.ResultConfigList?.FirstOrDefault(result => result.Id == id);
                    return this.BuildPath(result, documentConfig);
                case "05":
                    var record = documentConfig.RecordConfigList?.FirstOrDefault(record => record.Id == id);
                    return this.BuildPath(record, documentConfig);
                case "06":
                    var process = documentConfig.ProcessConfigList?.FirstOrDefault(process => process.Id == id);
                    return this.BuildPath(process, documentConfig);
                case "07":
                    var schema = documentConfig.SchemaConfigList?.FirstOrDefault(schema => schema.Id == id);
                    return this.BuildPath(schema, documentConfig);
                default:
                    throw new Exception($"IDの形式が不正です。ID:{id}");
            }
        }

        private string BuildPath(SubjectConfig subjectConfig, FactStatusConfig documentConfig) {
            // パスの結合
            List<string> pathList = new List<string> {
                subjectConfig.PathName,
                "README.md"
            };
            return string.Join("/", pathList);
        }
        
        private string BuildPath(TodoConfig todoConfig, FactStatusConfig documentConfig) {
            // 親のSubjectを取得
            var subjectConfig = documentConfig.SubjectConfigList.First(subject => subject.Id == todoConfig.ParentId);

            // パスの結合
            List<string> pathList = new List<string> {
                subjectConfig.PathName,
                todoConfig.PathName,
                "README.md"
            };
            return string.Join("/", pathList);
        }
        
        private string BuildPath(EvidenceConfig evidenceConfig, FactStatusConfig documentConfig) {
            // 親のTodoを取得
            var todoConfig = documentConfig.TodoConfigList.First(todo => todo.Id == evidenceConfig.ParentId);
            // 親のSubjectを取得
            var subjectConfig = documentConfig.SubjectConfigList.First(subject => subject.Id == todoConfig.ParentId);
            
            // パスの結合
            List<string> pathList = new List<string> {
                subjectConfig.PathName,
                todoConfig.PathName,
                evidenceConfig.PathName,
                "README.md"
            };
            return string.Join("/", pathList);
        }
        
        private string BuildPath(ResultConfig resultConfig, FactStatusConfig documentConfig) {
            // 親のEvidenceを取得
            var evidenceConfig = documentConfig.EvidenceConfigList.First(evidence => evidence.Id == resultConfig.ParentId);
            // 親のTodoを取得
            var todoConfig = documentConfig.TodoConfigList.First(todo => todo.Id == evidenceConfig.ParentId);
            // 親のSubjectを取得
            var subjectConfig = documentConfig.SubjectConfigList.First(subject => subject.Id == todoConfig.ParentId);
            
            // パスの結合
            List<string> pathList = new List<string> {
                subjectConfig.PathName,
                todoConfig.PathName,
                evidenceConfig.PathName,
                resultConfig.PathName,
                "README.md"
            };
            return string.Join("/", pathList);
        }
        
        private string BuildPath(RecordConfig recordConfig, FactStatusConfig documentConfig) {
            // 親のResultを取得
            var resultConfig = documentConfig.ResultConfigList.First(result => result.Id == recordConfig.ParentId);
            // 親のEvidenceを取得
            var evidenceConfig = documentConfig.EvidenceConfigList.First(evidence => evidence.Id == resultConfig.ParentId);
            // 親のTodoを取得
            var todoConfig = documentConfig.TodoConfigList.First(todo => todo.Id == evidenceConfig.ParentId);
            // 親のSubjectを取得
            var subjectConfig = documentConfig.SubjectConfigList.First(subject => subject.Id == todoConfig.ParentId);
            
            // パスの結合
            List<string> pathList = new List<string> {
                subjectConfig.PathName,
                todoConfig.PathName,
                evidenceConfig.PathName,
                resultConfig.PathName,
                recordConfig.PathName,
                "README.md"
            };
            return string.Join("/", pathList);
        }
        
        private string BuildPath(ProcessConfig recordConfig, FactStatusConfig documentConfig) {
            // 親のResultを取得
            var resultConfig = documentConfig.ResultConfigList.First(result => result.Id == recordConfig.ParentId);
            // 親のEvidenceを取得
            var evidenceConfig = documentConfig.EvidenceConfigList.First(evidence => evidence.Id == resultConfig.ParentId);
            // 親のTodoを取得
            var todoConfig = documentConfig.TodoConfigList.First(todo => todo.Id == evidenceConfig.ParentId);
            // 親のSubjectを取得
            var subjectConfig = documentConfig.SubjectConfigList.First(subject => subject.Id == todoConfig.ParentId);
            
            // パスの結合
            List<string> pathList = new List<string> {
                subjectConfig.PathName,
                todoConfig.PathName,
                evidenceConfig.PathName,
                resultConfig.PathName,
                recordConfig.PathName,
                "README.md"
            };
            return string.Join("/", pathList);
        }
        
        private string BuildPath(SchemaConfig recordConfig, FactStatusConfig documentConfig) {
            // 親のResultを取得
            var resultConfig = documentConfig.ResultConfigList.First(result => result.Id == recordConfig.ParentId);
            // 親のEvidenceを取得
            var evidenceConfig = documentConfig.EvidenceConfigList.First(evidence => evidence.Id == resultConfig.ParentId);
            // 親のTodoを取得
            var todoConfig = documentConfig.TodoConfigList.First(todo => todo.Id == evidenceConfig.ParentId);
            // 親のSubjectを取得
            var subjectConfig = documentConfig.SubjectConfigList.First(subject => subject.Id == todoConfig.ParentId);
            
            // パスの結合
            List<string> pathList = new List<string> {
                subjectConfig.PathName,
                todoConfig.PathName,
                evidenceConfig.PathName,
                resultConfig.PathName,
                recordConfig.PathName,
                "README.md"
            };
            return string.Join("/", pathList);
        }
        

        /// <summary>
        /// /Document/README.mdの生成
        /// </summary>
        /// <param name="subjectConfigList"></param>
        /// <returns></returns>
        private MarkdownItemDto CreateDocumentMarkdown(
            List<SubjectConfig> subjectConfigList,
            string filePath) {

            // Document/README.mdの生成
            var markdownList = new List<string>();
            markdownList.Add(Header(1, "ドキュメント"));
            // 主題一覧を追加
            markdownList.Add(Header(2, "主題一覧"));
            foreach (var subjectConfig in subjectConfigList) {
                markdownList.Add(Link(subjectConfig.Title, $"./{subjectConfig.PathName}/README.md"));
            }
            // 区切り線と上部READMEへのリンク
            markdownList.Add(HorizontalRule());
            markdownList.Add(LineBack());

            // markdownDtoに変換
            var markdownDto = new MarkdownItemDto() {
                Directory = filePath,
                Description = string.Join("  \n", markdownList)
            };
            return markdownDto;
        }

        private MarkdownItemDto CreateSubjectMarkdown(
            SubjectConfig subjectConfig,
            List<TodoConfig> todoConfigList,
            List<SchemaConfig> schemaConfigList,
            string filePath) {

            // Subject/README.mdの生成
            var markdownList = new List<string>();
            markdownList.Add(Header(1, subjectConfig.Title));
            // 企画内容
            markdownList.Add(Header(2, "企画内容"));
            markdownList.Add(Text(subjectConfig.Description));
            // 企画実装に紐づくTodoを抽出、追加
            markdownList.Add(Header(2, "企画実装"));
            var todoFiltered = todoConfigList.Where(todo => todo.ParentId == subjectConfig.Id).ToList();
            foreach (var todo in todoFiltered) {
                markdownList.Add(Link(todo.Title, $"./{todo.PathName}/README.md"));
            }
            // 企画構想に紐づくSchemaを抽出、追加
            markdownList.Add(Header(2, "企画構想"));
            var schemaFiltered = schemaConfigList.Where(schema => schema.ParentId == subjectConfig.Id).ToList();
            foreach (var schema in schemaFiltered) {
                markdownList.Add(Link(schema.Title, $"./{schema.PathName}/README.md"));
            }
            // 区切り線と上部READMEへのリンク
            markdownList.Add(HorizontalRule());
            markdownList.Add(LineBack());

            // markdownDtoに変換
            MarkdownItemDto markdownDto = new() {
                Directory = filePath,
                Description = string.Join("  \n", markdownList)
            };
            return markdownDto;
        }

        private MarkdownItemDto CreateTodoMarkdown(
            TodoConfig todoConfig,
            List<EvidenceConfig> evidenceConfigList,
            List<ProcessConfig> processConfigList,
            List<SchemaConfig> schemaConfigList,
            string filePath) {

            // Todo/README.md作成
            var markdownList = new List<string>();
            markdownList.Add(Header(1, todoConfig.Title));
            // 実装内容
            markdownList.Add(Header(2, "実装内容"));
            markdownList.Add(Text(todoConfig.Description));
            // 実装証拠に紐づくEvidenceを抽出
            markdownList.Add(Header(2, "実装証拠"));
            var evidenceFiltered = evidenceConfigList.Where(evidence => evidence.ParentId == todoConfig.Id).ToList();
            foreach (var evidence in evidenceFiltered) {
                markdownList.Add(Link(evidence.Title, $"./{evidence.PathName}/README.md"));
            }
            // 実装手順に紐づくProcessを抽出
            markdownList.Add(Header(2, "実装手順"));
            var processFiltered = processConfigList.Where(process => process.ParentId == todoConfig.Id).ToList();
            foreach (var process in processFiltered) {
                markdownList.Add(Link(process.Title, $"./{process.PathName}/README.md"));
            }
            // 実装構想に紐づくSchemaを抽出
            markdownList.Add(Header(2, "実装構想"));
            var schemaFiltered = schemaConfigList.Where(schema => schema.ParentId == todoConfig.Id).ToList();
            foreach (var schema in schemaFiltered) {
                markdownList.Add(Link(schema.Title, $"./{schema.PathName}/README.md"));
            }
            // 区切り線と上部READMEへのリンク
            markdownList.Add(HorizontalRule());
            markdownList.Add(LineBack());

            // markdownDtoに変換
            MarkdownItemDto markdownDto = new() {
                Directory = filePath,
                Description = string.Join("  \n", markdownList)
            };
            return markdownDto;
        }

        private MarkdownItemDto CreateEvidenceMarkdown(
            EvidenceConfig evidenceConfig,
            List<ResultConfig> resultConfigList,
            List<ProcessConfig> processConfigList,
            List<SchemaConfig> schemaConfigList,
            string filePath) {

            // Evidence/README.md作成
            var markdownList = new List<string>();
            markdownList.Add(Header(1, evidenceConfig.Title));
            // 証拠内容
            markdownList.Add(Header(2, "証拠内容"));
            markdownList.Add(Text(evidenceConfig.Description));
            // 証拠結果に紐づくResultを抽出、追加
            markdownList.Add(Header(2, "証拠結果"));
            var evidenceFiltered = resultConfigList.Where(result => result.ParentId == evidenceConfig.Id).ToList();
            foreach (var evidence in evidenceFiltered) {
                markdownList.Add(Link(evidence.Title, $"./{evidence.PathName}/README.md"));
            }
            // 証拠手順に紐づくProcessを抽出、追加
            markdownList.Add(Header(2, "証拠手順"));
            var processFiltered = processConfigList.Where(process => process.ParentId == evidenceConfig.Id).ToList();
            foreach (var process in processFiltered) {
                markdownList.Add(Link(process.Title, $"./{process.PathName}/README.md"));
            }
            // 証拠手順に紐づくSchemaを抽出、追加
            markdownList.Add(Header(2, "証拠構想"));
            var schemaFiltered = schemaConfigList.Where(schema => schema.ParentId == evidenceConfig.Id).ToList();
            foreach (var schema in schemaFiltered) {
                markdownList.Add(Link(schema.Title, $"./{schema.PathName}/README.md"));
            }
            // 区切り線と上部READMEへのリンク
            markdownList.Add(HorizontalRule());
            markdownList.Add(LineBack());

            // markdownDtoに変換
            MarkdownItemDto markdownDto = new() {
                Directory = filePath,
                Description = string.Join("  \n", markdownList)
            };
            return markdownDto;
        }

        private MarkdownItemDto CreateResultMarkdown(
            ResultConfig resultConfig,
            List<RecordConfig> recordConfigList,
            List<ArgumentConfig> argumentConfigList,
            string filePath) {

            // Result/README.md作成
            var markdownList = new List<string>();
            markdownList.Add(Header(1, resultConfig.Title));
            // 結果区分
            markdownList.Add(Header(2, "結果区分(正常値/異常値)"));
            markdownList.Add((resultConfig.Success) ? "正常値" : "異常値");
            // 期待値
            markdownList.Add(Header(2, "期待値"));
            markdownList.Add(Text(resultConfig.ExpectedValue));
            // 期待型式
            markdownList.Add(Header(2, "期待型式"));
            markdownList.Add(Text(resultConfig.ExpectedType));
            // 結果に紐づくexceptionを抽出、追加
            markdownList.Add(Header(2, "例外型式"));
            markdownList.Add(Text(resultConfig.ExceptionType));
            // 結果に紐づくargumentを抽出、追加
            markdownList.Add(Header(2, "引数"));
            var argumentFiltered = argumentConfigList.Where(record => record.ParentId == resultConfig.Id).ToList();
            foreach (var argument in argumentFiltered) {
                markdownList.Add($"{argument.Type} {argument.Key} = {argument.Value}\n");
            }
            // 結果に紐づくrecordを抽出、追加
            markdownList.Add(Header(2, "記録一覧"));
            var recordFiltered = recordConfigList.Where(record => record.ParentId == resultConfig.Id).ToList();
            foreach (var record in recordFiltered) {
                markdownList.Add(Link(record.Title, $"./{record.PathName}/README.md"));
            }
            // 区切り線と上部READMEへのリンク
            markdownList.Add(HorizontalRule());
            markdownList.Add(LineBack());

            // markdownDtoに変換
            MarkdownItemDto markdownDto = new() {
                Directory = filePath,
                Description = string.Join("  \n", markdownList)
            };
            return markdownDto;
        }

        private MarkdownItemDto CreateRecordMarkdown(
            RecordConfig recordConfig,
            string filePath) {

            // Record/README.md作成
            var markdownList = new List<string>();
            markdownList.Add(Header(1, recordConfig.Title));
            // 確認日
            markdownList.Add(Header(2, "確認日(yyyy-MM-dd HH:mm:ss)"));
            markdownList.Add(Text(recordConfig.Date.ToString("yyyy-MM-dd HH:mm:ss")));
            // 確認者
            markdownList.Add(Header(2, "確認者"));
            markdownList.Add(Text(recordConfig.Reviewer));
            // 判定
            markdownList.Add(Header(2, "判定(OK/NG)"));
            markdownList.Add((recordConfig.Success) ? "OK" : "NG");
            // 期待値
            markdownList.Add(Header(2, "期待値"));
            markdownList.Add(Text(recordConfig.ExpectedValue));
            // 期待型式
            markdownList.Add(Header(2, "期待型式"));
            markdownList.Add(Text(recordConfig.ExpectedType));
            // 記録に紐づくexceptionを抽出、追加
            markdownList.Add(Header(2, "例外型式"));
            markdownList.Add(Bullet(recordConfig.ExceptionType));
            markdownList.Add(Header(2, "メッセージ"));
            markdownList.Add(Text(recordConfig.Message));
            // 区切り線と上部READMEへのリンク
            markdownList.Add(HorizontalRule());
            markdownList.Add(LineBack());

            // markdownDtoに変換
            MarkdownItemDto markdownDto = new() {
                Directory = filePath,
                Description = string.Join("  \n", markdownList)
            };
            return markdownDto;
        }

        private MarkdownItemDto CreateProcessMarkdown(
            ProcessConfig processConfig,
            List<StepConfig> stepConfigList,
            string filePath) {

            // Process/README.md作成
            var markdownList = new List<string>();
            markdownList.Add(Header(1, processConfig.Title));
            // 手順に紐づくstepを抽出、追加
            var stepFiltered = stepConfigList.Where(step => step.ParentId == processConfig.Id).ToList();
            foreach (var step in stepFiltered) {
                markdownList.Add(Ordered(step.Value));
            }
            // 区切り線と上部READMEへのリンク
            markdownList.Add(HorizontalRule());
            markdownList.Add(LineBack());

            // markdownDtoに変換
            MarkdownItemDto markdownDto = new() {
                Directory = filePath,
                Description = string.Join("  \n", markdownList)
            };
            return markdownDto;
        }

        private MarkdownItemDto CreateSchemaMarkdown(
            SchemaConfig schemaConfig,
            string filePath) {

            // Schema/README.md作成
            var markdownList = new List<string>();
            markdownList.Add(Header(1, schemaConfig.Title));
            // 体験
            markdownList.Add(Header(2, "体験"));
            markdownList.Add(schemaConfig.Experience);
            // 評価
            markdownList.Add(Header(2, "評価"));
            markdownList.Add(schemaConfig.Evaluation);
            // 仮説
            markdownList.Add(Header(2, "仮説"));
            markdownList.Add(schemaConfig.Hypothesis);
            // 抽象目標
            markdownList.Add(Header(2, "抽象目標"));
            markdownList.Add(schemaConfig.AbstractGoal);
            // 実行目標
            markdownList.Add(Header(2, "実行目標"));
            markdownList.Add(schemaConfig.ExecutionGoal);
            // 区切り線と上部READMEへのリンク
            markdownList.Add(HorizontalRule());
            markdownList.Add(LineBack());

            // markdownDtoに変換
            MarkdownItemDto markdownDto = new() {
                Directory = filePath,
                Description = string.Join("  \n", markdownList)
            };
            return markdownDto;
        }

        private SubjectConfig SearchSubjectConfig(string id, List<SubjectConfig> subjectConfigList) {
            return subjectConfigList.First(subject => subject.Id == id);
        }
        
        private TodoConfig SearchTodoConfig(string id, List<TodoConfig> todoConfigList) {
            return todoConfigList.First(todo => todo.Id == id);
        }

        private EvidenceConfig SearchEvidenceConfig(string id, List<EvidenceConfig> evidenceConfigList) {
            return evidenceConfigList.First(evidence => evidence.Id == id);
        }

        private ResultConfig SearchResultConfig(string id, List<ResultConfig> resultConfigList) {
            return resultConfigList.First(result => result.Id == id);
        }

        private RecordConfig SearchRecordConfig(string id, List<RecordConfig> recordConfigList) {
            return recordConfigList.First(record => record.Id == id);
        }

        private ProcessConfig SearchProcessConfig(string id, List<ProcessConfig> processConfigList) {
            return processConfigList.First(process => process.Id == id);
        }

        private SchemaConfig SearchSchemaConfig(string id, List<SchemaConfig> schemaConfigList) {
            return schemaConfigList.First(schema => schema.Id == id);
        }

        private string Text(string value) {
            return $"{value}";
        }

        /// <summary>
        /// ヘッダーの作成
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private string Header(int index, string value) {
            switch(index) {
                case 1:
                    return $"# {value}";
                case 2:
                    return $"## {value}";
                case 3:
                    return $"### {value}";
                case 4:
                    return $"#### {value}";
                case 5:
                    return $"##### {value}";
                case 6:
                    return $"###### {value}";
                default:
                    return value;
            }
        }

        private string Bullet(string value) {
            return $"- {value}\n";
        }

        private string BulletList(List<string> value) {
            StringBuilder listBuilder = new StringBuilder();
            foreach (var item in value) {
                listBuilder.AppendLine($"- {item}");
            }
            return listBuilder.ToString();
        }

        private string Ordered(string value) {
            return $"1. {value}\n";
        }
        private string OrderedList(List<string> value) {
            StringBuilder listBuilder = new StringBuilder();
            for (int i = 0; i < value.Count; i++) {
                listBuilder.AppendLine($"{i + 1}. {value[i]}");
            }
            return listBuilder.ToString();
        }

        private string BlockQuoteList(List<string> value) {
            StringBuilder listBuilder = new StringBuilder();
            foreach (var item in value) {
                listBuilder.AppendLine($"> {item}");
            }
            return listBuilder.ToString();
        }

        private string CodeSpans(List<string> value) {
            StringBuilder codeBuilder = new StringBuilder();
            codeBuilder.Append($"```");
            foreach (var item in value) {
                codeBuilder.Append($"{item}  ");
            }
            codeBuilder.Append($"```");
            return codeBuilder.ToString().Trim();
        }

        private string Link(string text, string url) {
            return $"[{text}]({url})  ";
        }

        private string Image(string altText, string url) {
            return $"![{altText}]({url})";
        }

        private string Table(List<string> headers, List<List<string>> rows) {
            StringBuilder tableBuilder = new StringBuilder();
            // ヘッダー行の追加
            tableBuilder.AppendLine("| " + string.Join(" | ", headers) + " |");
            tableBuilder.AppendLine("|" + string.Join("|", headers.Select(_ => "---")) + "|");
            // データ行の追加
            foreach (var row in rows) {
                tableBuilder.AppendLine("| " + string.Join(" | ", row) + " |");
            }
            return tableBuilder.ToString();
        }

        private string HorizontalRule() {
            return "\n---";
        }

        private string LineBack() {
            return "[Back](../README.md)";
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MarkdownDtoBuilder() {
            this._markdownDtos = new List<MarkdownItemDto>();
        }
    }
}
