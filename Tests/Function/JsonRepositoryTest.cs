using FactStatusTool.Scripts.Function;
using FactStatusTool.Scripts.Variable;
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

namespace FactStatusTool.Tests.Function {
    public class JsonRepositoryTest(ITestOutputHelper output) {
        [Fact]
        public void LoadJsonByRelationalTest() {
            JsonByRelationalDto relationalDataDto = new JsonRepository().LoadJsonByRelational("D:/Action/FactStatusTool/Documents/RelationalData.json");

            Assert.NotNull(relationalDataDto);
            Assert.NotNull(relationalDataDto.Subjects);
            Assert.NotEmpty(relationalDataDto.Subjects);

            FileInfo fileInfo = new("D:/Action/FactStatusTool/Documents/RelationalSaveTest.json");
            if (fileInfo.Exists) {
                fileInfo.Delete();
            }
            
            new JsonRepository().SaveJsonByRelational(fileInfo.ToString(), relationalDataDto);



            foreach (SubjectJsonByRelationalDto projectDto in relationalDataDto.Subjects) {
                output.WriteLine($"Project_Id: {projectDto.Id}");
                output.WriteLine($"Project_Path: {projectDto.PathName}");
                output.WriteLine($"Project_Title: {projectDto.Title}");
                output.WriteLine($"Project_Description: {projectDto.Description}");
            }

            foreach (TodoJsonByRelationalDto todoDto in relationalDataDto.Todos) {
                output.WriteLine($"Todo_ParentId: {todoDto.ParentId}");
                output.WriteLine($"Todo_Id: {todoDto.Id}");
                output.WriteLine($"Todo_Path: {todoDto.PathName}");
                output.WriteLine($"Todo_Title: {todoDto.Title}");
                output.WriteLine($"Todo_Description: {todoDto.Description}");
            }

            foreach (EvidenceJsonByRelationalDto evidenceDto in relationalDataDto.Evidences) {
                output.WriteLine($"Evidence_ParentId: {evidenceDto.ParentId}");
                output.WriteLine($"Evidence_Id: {evidenceDto.Id}");
                output.WriteLine($"Evidence_Path: {evidenceDto.PathName}");
                output.WriteLine($"Evidence_Title: {evidenceDto.Title}");
                output.WriteLine($"Evidence_Description: {evidenceDto.Description}");
            }

            foreach (ResultJsonByRelationalDto resultDto in relationalDataDto.Results) {
                output.WriteLine($"Result_ParentId: {resultDto.ParentId}");
            }

            foreach (RecordJsonByRelationalDto recordDto in relationalDataDto.Records) {
                output.WriteLine($"Record_ParentId: {recordDto.ParentId}");

            }

            foreach (ProcessJsonByRelationalDto processDto in relationalDataDto.Processs) {
                output.WriteLine($"Process_ParentId: {processDto.ParentId}");
            }

            foreach (SchemaJsonByRelationalDto schemaDto in relationalDataDto.Schemas) {
                output.WriteLine($"Schema_ParentId: {schemaDto.ParentId}");
            }

            foreach (ArgumentJsonByRelationalDto argumentDto in relationalDataDto.Arguments) {
                output.WriteLine($"Argument_ParentId: {argumentDto.ParentId}");
            }

            foreach (StepJsonByRelationalDto stepDto in relationalDataDto.Steps) {
                output.WriteLine($"Step_ParentId: {stepDto.ParentId}");
            }
        }

        [Fact]
        public void LoadJsonByIdPatternRulesTest() {
            IdPatternRulesDto idPatternRulesDto = new JsonRepository().LoadJsonByIdPatternRules("D:/Action/__CoreTemplateIDCM/Documents/IdPatternRules.json");

            Assert.NotNull(idPatternRulesDto);
            Assert.NotNull(idPatternRulesDto.ClassTypes);
            Assert.NotEmpty(idPatternRulesDto.PropertyTypes);
        }
    }
}
