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
using FactStatus.Domain.Setup;
using FactStatus.Domain.Value;

namespace Tests.FactStatus.Logic {
    public class JsonRepositoryTest(ITestOutputHelper output) {
        [Fact]
        public void LoadJsonTest() {
            JsonDto jsonDto = new JsonRepository().LoadJson(new PathValue("D:/Action/FactStatusTool/Documents/RelationalData.json",PathTypeEnum.RootFile));

            Assert.NotNull(jsonDto);
            Assert.NotNull(jsonDto.SubjectConfigs);
            Assert.NotEmpty(jsonDto.SubjectConfigs);

            FileInfo fileInfo = new("D:/Action/FactStatusTool/Documents/RelationalSaveTest.json");
            if (fileInfo.Exists) {
                fileInfo.Delete();
            }
            
            new JsonRepository().SaveJson(new PathValue(fileInfo.ToString(),PathTypeEnum.RootFile), jsonDto);



            foreach (SubjectConfigJsonDto projectDto in jsonDto.SubjectConfigs) {
                output.WriteLine($"Project_Id: {projectDto.Id}");
                output.WriteLine($"Project_Path: {projectDto.PathName}");
                output.WriteLine($"Project_Title: {projectDto.Title}");
                output.WriteLine($"Project_Description: {projectDto.Description}");
            }

            foreach (AchievementConfigJsonDto achievementDto in jsonDto.AchievementConfigs) {
                output.WriteLine($"Achievement.Id: {achievementDto.Id}");
                output.WriteLine($"Achievement.PathName: {achievementDto.PathName}");
                output.WriteLine($"Achievement.Title: {achievementDto.Title}");
                output.WriteLine($"Achievement.Description: {achievementDto.Description}");
            }

            foreach (EvidenceConfigJsonDto evidenceDto in jsonDto.EvidenceConfigs) {
                output.WriteLine($"Evidence_Id: {evidenceDto.Id}");
                output.WriteLine($"Evidence_Path: {evidenceDto.PathName}");
                output.WriteLine($"Evidence_Title: {evidenceDto.Title}");
                output.WriteLine($"Evidence_Description: {evidenceDto.Description}");
                output.WriteLine($"Evidence_Description: {evidenceDto.Success}");
            }

            foreach (ResultConfigJsonDto resultDto in jsonDto.ResultConfigs) {
                output.WriteLine($"Result_ParentId: {resultDto.Id}");
            }

            foreach (RecordConfigJsonDto recordDto in jsonDto.RecordConfigs) {
                output.WriteLine($"Record_ParentId: {recordDto.Id}");

            }

            foreach (TodoConfigJsonDto todoDto in jsonDto.TodoConfigs) {
                output.WriteLine($"Todo.ParentId: {todoDto.Id}");
            }

            foreach (SchemaConfigJsonDto schemaDto in jsonDto.SchemaConfigs) {
                output.WriteLine($"Schema_ParentId: {schemaDto.Id}");
            }
        }

        [Fact]
        public void LoadJsonByIdPatternRulesTest() {
            IdPatternRulesDto idPatternRulesDto = new FactStatusRepository().LoadIdPatternRules(new PathValue("D:/Action/__CoreTemplateIDCM/Documents/IdPatternRules.json",PathTypeEnum.RootFile));

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
