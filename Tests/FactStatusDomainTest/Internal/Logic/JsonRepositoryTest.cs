using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using FactStatus.Domain.Internal.Setup;
using FactStatus.Domain.Api.Value;
using FactStatus.Domain.Internal.Value;

namespace FactStatus.Domain.Test.Internal.Logic {
    public class JsonRepositoryTest(ITestOutputHelper output) {
        [Fact]
        public void LoadJsonTest() {
            FactStatusDomainDao jsonDto = new JsonRepository().LoadJson(new PathValue("D:/Action/FactStatusTool/Documents/RelationalData.json",PathTypeEnum.RootFile));

            Assert.NotNull(jsonDto);
            Assert.NotNull(jsonDto.SubjectAggregates);
            Assert.NotEmpty(jsonDto.SubjectAggregates);

            FileInfo fileInfo = new("D:/Action/FactStatusTool/Documents/RelationalSaveTest.json");
            if (fileInfo.Exists) {
                fileInfo.Delete();
            }
            
            new JsonRepository().SaveJson(new PathValue(fileInfo.ToString(),PathTypeEnum.RootFile), jsonDto);



            foreach (SubjectAggregateJsonDto projectDto in jsonDto.SubjectAggregates) {
                output.WriteLine($"Project_Id: {projectDto.Id}");
                output.WriteLine($"Project_Path: {projectDto.PathName}");
                output.WriteLine($"Project_Title: {projectDto.Title}");
                output.WriteLine($"Project_Description: {projectDto.Description}");
            }

            foreach (AchievementAggregateJsonDto achievementDto in jsonDto.AchievementAggregates) {
                output.WriteLine($"Achievement.Id: {achievementDto.Id}");
                output.WriteLine($"Achievement.PathName: {achievementDto.PathName}");
                output.WriteLine($"Achievement.Title: {achievementDto.Title}");
                output.WriteLine($"Achievement.Description: {achievementDto.Description}");
            }

            foreach (EvidenceAggregateJsonDto evidenceDto in jsonDto.EvidenceAggregates) {
                output.WriteLine($"Evidence_Id: {evidenceDto.Id}");
                output.WriteLine($"Evidence_Path: {evidenceDto.PathName}");
                output.WriteLine($"Evidence_Title: {evidenceDto.Title}");
                output.WriteLine($"Evidence_Description: {evidenceDto.Description}");
                output.WriteLine($"Evidence_Description: {evidenceDto.Success}");
            }

            foreach (ResultAggregateJsonDto resultDto in jsonDto.ResultAggregates) {
                output.WriteLine($"Result_ParentId: {resultDto.Id}");
            }

            foreach (RecordAggregateJsonDto recordDto in jsonDto.RecordAggregates) {
                output.WriteLine($"Record_ParentId: {recordDto.Id}");

            }

            foreach (TodoAggregateJsonDto todoDto in jsonDto.TodoAggregates) {
                output.WriteLine($"Todo.ParentId: {todoDto.Id}");
            }

            foreach (SchemaAggregateJsonDto schemaDto in jsonDto.SchemaAggregates) {
                output.WriteLine($"Schema_ParentId: {schemaDto.Id}");
            }
        }

        [Fact]
        public void LoadJsonByIdPatternRulesTest() {
            IdPatternRulesDao idPatternRulesDto = new FactStatusDomainRepository().LoadIdPatternRules(new PathValue("D:/Action/__CoreTemplateIDCM/Documents/IdPatternRules.json",PathTypeEnum.RootFile));

            Assert.NotNull(idPatternRulesDto);
            Assert.NotNull(idPatternRulesDto.ClassTypes);
            Assert.NotEmpty(idPatternRulesDto.PropertyTypes);
        }

        /// <summary>
        /// テスト用Jsonファイルの作成
        /// </summary>
        private static void createJsonFile() {

        }

        /// <summary>
        /// テスト用Jsonファイルの削除
        /// </summary>
        private static void deleteJsonFile() {

        }
    }
}
