using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FactStatus.Domain.Internal.Setup {
    public class MarkdownDtoBuilder {
        private List<MarkdownItemDto> _markdownDtos;

        // 一時保留
        //public MarkdownDtoBuilder OfFactStatusAggregate(FactStatusAggregate documentAggregate) {
        //    // /Document/README.mdの生成
        //    MarkdownItemDto documentMarkdown = this.CreateDocumentMarkdown(
        //        documentAggregate.SubjectAggregateList,
        //        "Document/README.md");
        //    // リストに追加
        //    this._markdownDtos.Add(documentMarkdown);

        //    // /Subject/README.mdの生成
        //    foreach (SubjectAggregate subjectAggregate in documentAggregate.SubjectAggregateList) {
        //        // ファイルパスの生成
        //        string filePath = this.SearchFilePath(subjectAggregate.Id,documentAggregate);
        //        // マークダウンアイテムの生成
        //        MarkdownItemDto subjectMarkdown = this.CreateSubjectMarkdown(
        //            subjectAggregate,
        //            documentAggregate.TodoAggregateList,
        //            documentAggregate.SchemaAggregateList,
        //            $"Document/{filePath}");
        //        // リストに追加
        //        this._markdownDtos.Add(subjectMarkdown);
        //    }

        //    // /Todo/README.mdの生成
        //    foreach (TodoAggregate todoAggregate in documentAggregate.TodoAggregateList) {
        //        // ファイルパスの生成
        //        string filePath = this.SearchFilePath(todoAggregate.Id, documentAggregate);
        //        // マークダウンアイテムの生成
        //        MarkdownItemDto todoMarkdown = this.CreateTodoMarkdown(
        //            todoAggregate,
        //            documentAggregate.EvidenceAggregateList,
        //            documentAggregate.ProcessAggregateList,
        //            documentAggregate.SchemaAggregateList,
        //            $"Document/{filePath}");
        //        // リストに追加
        //        this._markdownDtos.Add(todoMarkdown);
        //    }

        //    // /Evidence/README.mdの生成
        //    foreach (EvidenceAggregate evidenceAggregate in documentAggregate.EvidenceAggregateList) {
        //        // ファイルパスの生成
        //        string filePath = this.SearchFilePath(evidenceAggregate.Id, documentAggregate);
        //        // マークダウンアイテムの生成
        //        MarkdownItemDto evidenceMarkdown = this.CreateEvidenceMarkdown(
        //            evidenceAggregate,
        //            documentAggregate.ResultAggregateList,
        //            documentAggregate.ProcessAggregateList,
        //            documentAggregate.SchemaAggregateList,
        //            $"Document/{filePath}");
        //        // リストに追加
        //        this._markdownDtos.Add(evidenceMarkdown);
        //    }

        //    // /Result/README.mdの生成
        //    foreach (ResultAggregate resultAggregate in documentAggregate.ResultAggregateList) {
        //        // ファイルパスの生成
        //        string filePath = this.SearchFilePath(resultAggregate.Id, documentAggregate);
        //        // マークダウンアイテムの生成
        //        MarkdownItemDto resultMarkdown = this.CreateResultMarkdown(
        //            resultAggregate,
        //            documentAggregate.RecordAggregateList,
        //            documentAggregate.ArgumentAggregateList,
        //            $"Document/{filePath}");
        //        // リストに追加
        //        this._markdownDtos.Add(resultMarkdown);
        //    }

        //    // /Record/README.mdの生成
        //    foreach (RecordAggregate recordAggregate in documentAggregate.RecordAggregateList) {
        //        // ファイルパスの生成
        //        string filePath = this.SearchFilePath(recordAggregate.Id, documentAggregate);
        //        // マークダウンアイテムの生成
        //        MarkdownItemDto recordMarkdown = this.CreateRecordMarkdown(
        //            recordAggregate,
        //            $"Document/{filePath}");
        //        // リストに追加
        //        this._markdownDtos.Add(recordMarkdown);
        //    }

        //    // /Process/README.mdの生成
        //    foreach (ProcessAggregate processAggregate in documentAggregate.ProcessAggregateList) {
        //        // ファイルパスの生成
        //        string filePath = this.SearchFilePath(processAggregate.Id, documentAggregate);
        //        // マークダウンアイテムの生成
        //        MarkdownItemDto processMarkdown = this.CreateProcessMarkdown(
        //            processAggregate,
        //            documentAggregate.StepAggregateList,
        //            $"Document/{filePath}");
        //        // リストに追加
        //        this._markdownDtos.Add(processMarkdown);
        //    }

        //    // /Schema/README.mdの生成
        //    foreach (SchemaAggregate schemaAggregate in documentAggregate.SchemaAggregateList) {
        //        // ファイルパスの生成
        //        string filePath = this.SearchFilePath(schemaAggregate.Id, documentAggregate);
        //        // マークダウンアイテムの生成
        //        MarkdownItemDto schemaMarkdown = this.CreateSchemaMarkdown(
        //            schemaAggregate,
        //            $"Document/{filePath}");
        //        // リストに追加
        //        this._markdownDtos.Add(schemaMarkdown);
        //    }
        //    return this;
        //}

        //public MarkdownDtoBuilder OfFactStatusAggregate(FactStatusAggregate documentAggregate, string id) {
        //    // ファイルパスの生成
        //    string filePath = this.SearchFilePath(id, documentAggregate);

        //    switch (id) {
        //        case "Document":
        //            MarkdownItemDto documentMarkdown = this.CreateDocumentMarkdown(
        //                documentAggregate.SubjectAggregateList,
        //                "Document/README.md");
        //            this._markdownDtos[0] = documentMarkdown;
        //            break;
        //        case "Subject":
        //            SubjectAggregate subjectAggregate = this.SearchSubjectAggregate(id, documentAggregate.SubjectAggregateList);
        //            MarkdownItemDto subjectMarkdown = this.CreateSubjectMarkdown(
        //                subjectAggregate,
        //                documentAggregate.TodoAggregateList,
        //                documentAggregate.SchemaAggregateList,
        //                $"Document/{filePath}");
        //            this._markdownDtos[0] = subjectMarkdown;
        //            break;
        //        case "Todo":
        //            TodoAggregate todoAggregate = this.SearchTodoAggregate(id, documentAggregate.TodoAggregateList);
        //            MarkdownItemDto todoMarkdown = this.CreateTodoMarkdown(
        //                todoAggregate,
        //                documentAggregate.EvidenceAggregateList,
        //                documentAggregate.ProcessAggregateList,
        //                documentAggregate.SchemaAggregateList,
        //                $"Document/{filePath}");
        //            this._markdownDtos[0] = todoMarkdown;
        //            break;
        //        case "Evidence":
        //            EvidenceAggregate evidenceAggregate = this.SearchEvidenceAggregate(id, documentAggregate.EvidenceAggregateList);
        //            MarkdownItemDto evidenceMarkdown = this.CreateEvidenceMarkdown(
        //                evidenceAggregate,
        //                documentAggregate.ResultAggregateList,
        //                documentAggregate.ProcessAggregateList,
        //                documentAggregate.SchemaAggregateList,
        //                $"Document/{filePath}");
        //            this._markdownDtos[0] = evidenceMarkdown;
        //            break;
        //        case "Result":
        //            ResultAggregate resultAggregate = this.SearchResultAggregate(id, documentAggregate.ResultAggregateList);
        //            MarkdownItemDto resultMarkdown = this.CreateResultMarkdown(
        //                resultAggregate,
        //                documentAggregate.RecordAggregateList,
        //                documentAggregate.ArgumentAggregateList,
        //                $"Document/{filePath}");
        //            this._markdownDtos[0] = resultMarkdown;
        //            break;
        //        case "Record":
        //            RecordAggregate recordAggregate = this.SearchRecordAggregate(id, documentAggregate.RecordAggregateList);
        //            MarkdownItemDto recordMarkdown = this.CreateRecordMarkdown(
        //                recordAggregate,
        //                $"Document/{filePath}");
        //            this._markdownDtos[0] = recordMarkdown;
        //            break;
        //        case "Process":
        //            ProcessAggregate processAggregate = this.SearchProcessAggregate(id, documentAggregate.ProcessAggregateList);
        //            MarkdownItemDto processMarkdown = this.CreateProcessMarkdown(
        //                processAggregate,
        //                documentAggregate.StepAggregateList,
        //                $"Document/{filePath}");
        //            this._markdownDtos[0] = processMarkdown;
        //            break;
        //        case "Schema":
        //            SchemaAggregate schemaAggregate = this.SearchSchemaAggregate(id, documentAggregate.SchemaAggregateList);
        //            MarkdownItemDto schemaMarkdown = this.CreateSchemaMarkdown(
        //                schemaAggregate,
        //                $"Document/{filePath}");
        //            this._markdownDtos[0] = schemaMarkdown;
        //            break;
        //    }
        //    return this;
        //}

        ///// <summary>
        ///// MarkdownDtoの生成
        ///// </summary>
        ///// <returns></returns>
        //public MarkdownItemDto Build() {
        //    return new MarkdownItemDto {
        //        Directory = this._markdownDtos[0].Directory,
        //        Description = this._markdownDtos[0].Description
        //    };
        //}

        ///// <summary>
        ///// MarkdownListDtoの生成
        ///// </summary>
        ///// <returns></returns>
        //public MarkdownDto ListBuild() {
        //    return new MarkdownDto {
        //        MarkdownItemDtoList = this._markdownDtos,
        //    };
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="documentAggregate"></param>
        ///// <returns></returns>
        //private string SearchFilePath(string id, FactStatusAggregate documentAggregate) {
        //    string classTypeId = id.Substring(id.Length - 2);
        //    // idに紐づくデータを抽出
        //    switch(classTypeId) {
        //        case "01":
        //            var subject = documentAggregate.SubjectAggregateList?.FirstOrDefault(subject => subject.Id == id);
        //            return this.BuildPath(subject, documentAggregate);
        //        case "02":
        //            var todo = documentAggregate.TodoAggregateList?.FirstOrDefault(todo => todo.Id == id);
        //            return this.BuildPath(todo, documentAggregate);
        //        case "03":
        //            var evidence = documentAggregate.EvidenceAggregateList?.FirstOrDefault(evidence => evidence.Id == id);
        //            return this.BuildPath(evidence, documentAggregate);
        //        case "04":
        //            var result = documentAggregate.ResultAggregateList?.FirstOrDefault(result => result.Id == id);
        //            return this.BuildPath(result, documentAggregate);
        //        case "05":
        //            var record = documentAggregate.RecordAggregateList?.FirstOrDefault(record => record.Id == id);
        //            return this.BuildPath(record, documentAggregate);
        //        case "06":
        //            var process = documentAggregate.ProcessAggregateList?.FirstOrDefault(process => process.Id == id);
        //            return this.BuildPath(process, documentAggregate);
        //        case "07":
        //            var schema = documentAggregate.SchemaAggregateList?.FirstOrDefault(schema => schema.Id == id);
        //            return this.BuildPath(schema, documentAggregate);
        //        default:
        //            throw new Exception($"IDの形式が不正です。ID:{id}");
        //    }
        //}

        //private string BuildPath(SubjectAggregate subjectAggregate, FactStatusAggregate documentAggregate) {
        //    // パスの結合
        //    List<string> pathList = new List<string> {
        //        subjectAggregate.PathName,
        //        "README.md"
        //    };
        //    return string.Join("/", pathList);
        //}

        //private string BuildPath(IParentAggregate commonAggregate, FactStatusAggregate documentAggregate) {
        //    // 親のAggregateを取得
        //    var parentAggregate = documentAggregate.SubjectAggregateList.First(subject => subject.Id == commonAggregate.ParentId);

        //    // パスの結合
        //    List<string> pathList = new List<string> {
        //        parentAggregate.PathName,
        //        commonAggregate.PathName,
        //        "README.md"
        //    };
        //    return string.Join("/", pathList);
        //}


        ///// <summary>
        ///// /Document/README.mdの生成
        ///// </summary>
        ///// <param name="subjectAggregateList"></param>
        ///// <returns></returns>
        //private MarkdownItemDto CreateDocumentMarkdown(
        //    List<SubjectAggregate> subjectAggregateList,
        //    string filePath) {

        //    // Document/README.mdの生成
        //    var markdownList = new List<string>();
        //    markdownList.Add(Header(1, "ドキュメント"));
        //    // 主題一覧を追加
        //    markdownList.Add(Header(2, "主題一覧"));
        //    foreach (var subjectAggregate in subjectAggregateList) {
        //        markdownList.Add(Link(subjectAggregate.Title, $"./{subjectAggregate.PathName}/README.md"));
        //    }
        //    // 区切り線と上部READMEへのリンク
        //    markdownList.Add(HorizontalRule());
        //    markdownList.Add(LineBack());

        //    // markdownDtoに変換
        //    var markdownDto = new MarkdownItemDto() {
        //        Directory = filePath,
        //        Description = string.Join("  \n", markdownList)
        //    };
        //    return markdownDto;
        //}

        //private MarkdownItemDto CreateSubjectMarkdown(
        //    SubjectAggregate subjectAggregate,
        //    List<AchievementAggregate> achievementAggregateList,
        //    List<SchemaAggregate> schemaAggregateList,
        //    string filePath) {

        //    // Subject/README.mdの生成
        //    var markdownList = new List<string>();
        //    markdownList.Add(Header(1, subjectAggregate.Title));
        //    // 企画内容
        //    markdownList.Add(Header(2, "企画内容"));
        //    markdownList.Add(Text(subjectAggregate.Description));
        //    // 企画実装に紐づくTodoを抽出、追加
        //    markdownList.Add(Header(2, "企画達成"));
        //    var achievementFiltered = achievementAggregateList.Where(achievement => achievement.ParentId == subjectAggregate.Id).ToList();
        //    foreach (var achievement in achievementFiltered) {
        //        markdownList.Add(Link(achievement.Title, $"./{achievement.PathName}/README.md"));
        //    }
        //    // 企画構想に紐づくSchemaを抽出、追加
        //    markdownList.Add(Header(2, "企画構想"));
        //    var schemaFiltered = schemaAggregateList.Where(schema => schema.ParentId == subjectAggregate.Id).ToList();
        //    foreach (var schema in schemaFiltered) {
        //        markdownList.Add(Link(schema.Title, $"./{schema.PathName}/README.md"));
        //    }
        //    // 区切り線と上部READMEへのリンク
        //    markdownList.Add(HorizontalRule());
        //    markdownList.Add(LineBack());

        //    // markdownDtoに変換
        //    MarkdownItemDto markdownDto = new() {
        //        Directory = filePath,
        //        Description = string.Join("  \n", markdownList)
        //    };
        //    return markdownDto;
        //}

        //private MarkdownItemDto CreateTodoMarkdown(
        //    TodoAggregate todoAggregate,
        //    List<EvidenceAggregate> evidenceAggregateList,
        //    List<ProcessAggregate> processAggregateList,
        //    List<SchemaAggregate> schemaAggregateList,
        //    string filePath) {

        //    // Todo/README.md作成
        //    var markdownList = new List<string>();
        //    markdownList.Add(Header(1, todoAggregate.Title));
        //    // 実装内容
        //    markdownList.Add(Header(2, "実装内容"));
        //    markdownList.Add(Text(todoAggregate.Description));
        //    // 実装証拠に紐づくEvidenceを抽出
        //    markdownList.Add(Header(2, "実装証拠"));
        //    var evidenceFiltered = evidenceAggregateList.Where(evidence => evidence.ParentId == todoAggregate.Id).ToList();
        //    foreach (var evidence in evidenceFiltered) {
        //        markdownList.Add(Link(evidence.Title, $"./{evidence.PathName}/README.md"));
        //    }
        //    // 実装手順に紐づくProcessを抽出
        //    markdownList.Add(Header(2, "実装手順"));
        //    var processFiltered = processAggregateList.Where(process => process.ParentId == todoAggregate.Id).ToList();
        //    foreach (var process in processFiltered) {
        //        markdownList.Add(Link(process.Title, $"./{process.PathName}/README.md"));
        //    }
        //    // 実装構想に紐づくSchemaを抽出
        //    markdownList.Add(Header(2, "実装構想"));
        //    var schemaFiltered = schemaAggregateList.Where(schema => schema.ParentId == todoAggregate.Id).ToList();
        //    foreach (var schema in schemaFiltered) {
        //        markdownList.Add(Link(schema.Title, $"./{schema.PathName}/README.md"));
        //    }
        //    // 区切り線と上部READMEへのリンク
        //    markdownList.Add(HorizontalRule());
        //    markdownList.Add(LineBack());

        //    // markdownDtoに変換
        //    MarkdownItemDto markdownDto = new() {
        //        Directory = filePath,
        //        Description = string.Join("  \n", markdownList)
        //    };
        //    return markdownDto;
        //}

        //private MarkdownItemDto CreateEvidenceMarkdown(
        //    EvidenceAggregate evidenceAggregate,
        //    List<ResultAggregate> resultAggregateList,
        //    List<ProcessAggregate> processAggregateList,
        //    List<SchemaAggregate> schemaAggregateList,
        //    string filePath) {

        //    // Evidence/README.md作成
        //    var markdownList = new List<string>();
        //    markdownList.Add(Header(1, evidenceAggregate.Title));
        //    // 証拠内容
        //    markdownList.Add(Header(2, "証拠内容"));
        //    markdownList.Add(Text(evidenceAggregate.Description));
        //    // 証拠結果に紐づくResultを抽出、追加
        //    markdownList.Add(Header(2, "証拠結果"));
        //    var evidenceFiltered = resultAggregateList.Where(result => result.ParentId == evidenceAggregate.Id).ToList();
        //    foreach (var evidence in evidenceFiltered) {
        //        markdownList.Add(Link(evidence.Title, $"./{evidence.PathName}/README.md"));
        //    }
        //    // 証拠手順に紐づくProcessを抽出、追加
        //    markdownList.Add(Header(2, "証拠手順"));
        //    var processFiltered = processAggregateList.Where(process => process.ParentId == evidenceAggregate.Id).ToList();
        //    foreach (var process in processFiltered) {
        //        markdownList.Add(Link(process.Title, $"./{process.PathName}/README.md"));
        //    }
        //    // 証拠手順に紐づくSchemaを抽出、追加
        //    markdownList.Add(Header(2, "証拠構想"));
        //    var schemaFiltered = schemaAggregateList.Where(schema => schema.ParentId == evidenceAggregate.Id).ToList();
        //    foreach (var schema in schemaFiltered) {
        //        markdownList.Add(Link(schema.Title, $"./{schema.PathName}/README.md"));
        //    }
        //    // 区切り線と上部READMEへのリンク
        //    markdownList.Add(HorizontalRule());
        //    markdownList.Add(LineBack());

        //    // markdownDtoに変換
        //    MarkdownItemDto markdownDto = new() {
        //        Directory = filePath,
        //        Description = string.Join("  \n", markdownList)
        //    };
        //    return markdownDto;
        //}

        //private MarkdownItemDto CreateResultMarkdown(
        //    ResultAggregate resultAggregate,
        //    List<RecordAggregate> recordAggregateList,
        //    List<ArgumentAggregate> argumentAggregateList,
        //    string filePath) {

        //    // Result/README.md作成
        //    var markdownList = new List<string>();
        //    markdownList.Add(Header(1, resultAggregate.Title));
        //    // 結果区分
        //    markdownList.Add(Header(2, "結果区分(正常値/異常値)"));
        //    markdownList.Add((resultAggregate.Success) ? "正常値" : "異常値");
        //    // 期待値
        //    markdownList.Add(Header(2, "期待値"));
        //    markdownList.Add(Text(resultAggregate.ExpectedValue));
        //    // 期待型式
        //    markdownList.Add(Header(2, "期待型式"));
        //    markdownList.Add(Text(resultAggregate.ExpectedType));
        //    // 結果に紐づくexceptionを抽出、追加
        //    markdownList.Add(Header(2, "例外型式"));
        //    markdownList.Add(Text(resultAggregate.ExceptionType));
        //    // 結果に紐づくargumentを抽出、追加
        //    markdownList.Add(Header(2, "引数"));
        //    var argumentFiltered = argumentAggregateList.Where(record => record.ParentId == resultAggregate.Id).ToList();
        //    foreach (var argument in argumentFiltered) {
        //        markdownList.Add($"{argument.Type} {argument.Key} = {argument.Value}\n");
        //    }
        //    // 結果に紐づくrecordを抽出、追加
        //    markdownList.Add(Header(2, "記録一覧"));
        //    var recordFiltered = recordAggregateList.Where(record => record.ParentId == resultAggregate.Id).ToList();
        //    foreach (var record in recordFiltered) {
        //        markdownList.Add(Link(record.Title, $"./{record.PathName}/README.md"));
        //    }
        //    // 区切り線と上部READMEへのリンク
        //    markdownList.Add(HorizontalRule());
        //    markdownList.Add(LineBack());

        //    // markdownDtoに変換
        //    MarkdownItemDto markdownDto = new() {
        //        Directory = filePath,
        //        Description = string.Join("  \n", markdownList)
        //    };
        //    return markdownDto;
        //}

        //private MarkdownItemDto CreateRecordMarkdown(
        //    RecordAggregate recordAggregate,
        //    string filePath) {

        //    // Record/README.md作成
        //    var markdownList = new List<string>();
        //    markdownList.Add(Header(1, recordAggregate.Title));
        //    // 確認日
        //    markdownList.Add(Header(2, "確認日(yyyy-MM-dd HH:mm:ss)"));
        //    markdownList.Add(Text(recordAggregate.Date.ToString("yyyy-MM-dd HH:mm:ss")));
        //    // 確認者
        //    markdownList.Add(Header(2, "確認者"));
        //    markdownList.Add(Text(recordAggregate.Reviewer));
        //    // 判定
        //    markdownList.Add(Header(2, "判定(OK/NG)"));
        //    markdownList.Add((recordAggregate.Success) ? "OK" : "NG");
        //    // 期待値
        //    markdownList.Add(Header(2, "期待値"));
        //    markdownList.Add(Text(recordAggregate.ExpectedValue));
        //    // 期待型式
        //    markdownList.Add(Header(2, "期待型式"));
        //    markdownList.Add(Text(recordAggregate.ExpectedType));
        //    // 記録に紐づくexceptionを抽出、追加
        //    markdownList.Add(Header(2, "例外型式"));
        //    markdownList.Add(Bullet(recordAggregate.ExceptionType));
        //    markdownList.Add(Header(2, "メッセージ"));
        //    markdownList.Add(Text(recordAggregate.Message));
        //    // 区切り線と上部READMEへのリンク
        //    markdownList.Add(HorizontalRule());
        //    markdownList.Add(LineBack());

        //    // markdownDtoに変換
        //    MarkdownItemDto markdownDto = new() {
        //        Directory = filePath,
        //        Description = string.Join("  \n", markdownList)
        //    };
        //    return markdownDto;
        //}


        //private MarkdownItemDto CreateProcessMarkdown(
        //    ProcessAggregate processAggregate,
        //    List<StepAggregate> stepAggregateList,
        //    string filePath) {

        //    // Process/README.md作成
        //    var markdownList = new List<string>();
        //    markdownList.Add(Header(1, processAggregate.Title));
        //    // 手順に紐づくstepを抽出、追加
        //    var stepFiltered = stepAggregateList.Where(step => step.ParentId == processAggregate.Id).ToList();
        //    foreach (var step in stepFiltered) {
        //        markdownList.Add(Ordered(step.Value));
        //    }
        //    // 区切り線と上部READMEへのリンク
        //    markdownList.Add(HorizontalRule());
        //    markdownList.Add(LineBack());

        //    // markdownDtoに変換
        //    MarkdownItemDto markdownDto = new() {
        //        Directory = filePath,
        //        Description = string.Join("  \n", markdownList)
        //    };
        //    return markdownDto;
        //}

        //private MarkdownItemDto CreateSchemaMarkdown(
        //    SchemaAggregate schemaAggregate,
        //    string filePath) {

        //    // Schema/README.md作成
        //    var markdownList = new List<string>();
        //    markdownList.Add(Header(1, schemaAggregate.Title));
        //    // 体験
        //    markdownList.Add(Header(2, "体験"));
        //    markdownList.Add(schemaAggregate.Experience);
        //    // 評価
        //    markdownList.Add(Header(2, "評価"));
        //    markdownList.Add(schemaAggregate.Evaluation);
        //    // 仮説
        //    markdownList.Add(Header(2, "仮説"));
        //    markdownList.Add(schemaAggregate.Hypothesis);
        //    // 抽象目標
        //    markdownList.Add(Header(2, "抽象目標"));
        //    markdownList.Add(schemaAggregate.AbstractionGoal);
        //    // 実行目標
        //    markdownList.Add(Header(2, "実行目標"));
        //    markdownList.Add(schemaAggregate.ExecutionGoal);
        //    // 区切り線と上部READMEへのリンク
        //    markdownList.Add(HorizontalRule());
        //    markdownList.Add(LineBack());

        //    // markdownDtoに変換
        //    MarkdownItemDto markdownDto = new() {
        //        Directory = filePath,
        //        Description = string.Join("  \n", markdownList)
        //    };
        //    return markdownDto;
        //}

        //private SubjectAggregate SearchSubjectAggregate(string id, List<SubjectAggregate> subjectAggregateList) {
        //    return subjectAggregateList.First(subject => subject.Id == id);
        //}
        
        //private AchievementAggregate SearchAchievementAggregate(string id, List<AchievementAggregate> achievementAggregateList) {
        //    return achievementAggregateList.First(achievement => achievement.Id == id);
        //}

        //private EvidenceAggregate SearchEvidenceAggregate(string id, List<EvidenceAggregate> evidenceAggregateList) {
        //    return evidenceAggregateList.First(evidence => evidence.Id == id);
        //}

        //private ResultAggregate SearchResultAggregate(string id, List<ResultAggregate> resultAggregateList) {
        //    return resultAggregateList.First(result => result.Id == id);
        //}

        //private RecordAggregate SearchRecordAggregate(string id, List<RecordAggregate> recordAggregateList) {
        //    return recordAggregateList.First(record => record.Id == id);
        //}

        //private TodoAggregate SearchProcessAggregate(string id, List<TodoAggregate> todoAggregateList) {
        //    return todoAggregateList.First(todo => todo.Id == id);
        //}

        //private SchemaAggregate SearchSchemaAggregate(string id, List<SchemaAggregate> schemaAggregateList) {
        //    return schemaAggregateList.First(schema => schema.Id == id);
        //}

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
            _markdownDtos = new List<MarkdownItemDto>();
        }
    }
}
