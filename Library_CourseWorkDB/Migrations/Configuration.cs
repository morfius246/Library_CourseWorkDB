using System.Collections.Generic;
using Library_CourseWorkDB.Models;

namespace Library_CourseWorkDB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library_CourseWorkDB.Models.HomeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Library_CourseWorkDB.Models.HomeContext context)
        {
            List<Author> authors = new List<Author>
            {
                new Author { Name = "������", LastName = "������", SecondName = "���������" },
                new Author { Name = "�����", LastName = "���������", SecondName = "��������" },
                new Author { Name = "������", LastName = "������", SecondName = null }
            };
            authors.ForEach(a => context.Authors.AddOrUpdate(t => t.LastName, a));
            context.SaveChanges();


            List<Status> statuses = new List<Status> {
                new Status { Name = "available" },
                new Status { Name = "reading room" },
                new Status { Name = "given away" }
                };
            statuses.ForEach(s => context.Statuses.AddOrUpdate(t => t.Name, s));
            context.SaveChanges();

            List<UDC> UDCs = new List<UDC>
            {
                new UDC{ Code = "0", Description = "��������� ����"},
                    new UDC{ Code = "00", Description = "������� ������� ����� �� ��������"},
                        new UDC{ Code = "001", Description = "����� �� ������ � ������. ���������� �������� �����"},
                            new UDC{ Code = "001.1", Description = "������� �������� ��� �����"},
                            new UDC{ Code = "001.2", Description = "�������'���� �� ������ �������� �����"},
                            new UDC{ Code = "001.3", Description = "�������� �����"},
                            new UDC{ Code = "001.4", Description = "���������� ����������. ������� ������������"},
                            new UDC{ Code = "001.5", Description = "������ ����. ó������. �������"},
                            new UDC{ Code = "001.6", Description = "������ �����"},
                            new UDC{ Code = "001.8", Description = "����������"},
                            new UDC{ Code = "001.9", Description = "�������������� ����� � �����������"},
                        new UDC{ Code = "002", Description = "������������. �����. �������������. ���������"},
                        new UDC{ Code = "003", Description = "������� ������ �� ���������"},
                        new UDC{ Code = "004", Description = "����'������ ����� �� ���������. ������������ ����'�����"},
                            new UDC{ Code = "004.2", Description = "����'������ �����������"},
                            new UDC{ Code = "004.3", Description = "�������� ������������ ����'�����"},
                            new UDC{ Code = "004.4", Description = "��������� ������������"},
                            new UDC{ Code = "004.5", Description = "������� ������ � ����'�����. ��������� �����������"},
                            new UDC{ Code = "004.6", Description = "���"},
                            new UDC{ Code = "004.7", Description = "����'����� �����"},
                            new UDC{ Code = "004.8", Description = "������� ��������"},
                            new UDC{ Code = "004.9", Description = "��������� ������, �� �������� �� ����'������� ��������. �������� ����������� �������"},
                        new UDC{ Code = "006", Description = "�������������� �� ���������"},
                        new UDC{ Code = "008", Description = "���������. ��������. �������"},
                    new UDC{ Code = "01", Description = "����������� �� ����������� ���������. ��������"},
                        new UDC{ Code = "011", Description = "���������� �� ������� ����������"},
                        new UDC{ Code = "012", Description = "����������� ����� ������� ������ � ������� ����� �������� ������"},
                        new UDC{ Code = "013", Description = "����������� ������ ���� (���������) ������"},
                        new UDC{ Code = "014", Description = "����������� ����� �� ������� ������������� (�������� �����, ����� �� ���������� ����)"},
                        new UDC{ Code = "015", Description = "����������� �� ����� �������"},
                        new UDC{ Code = "016", Description = "������� ����������"},
                        new UDC{ Code = "017", Description = "�������� � ������. ������ ��������"},
                        new UDC{ Code = "018", Description = "�������� ��������"},
                        new UDC{ Code = "019", Description = "��������� ��� ��������� ��������"},
                    new UDC{ Code = "02", Description = "���������� ������"},
                        new UDC{ Code = "021", Description = "�������, ��������, �������, �������� �������"},
                        new UDC{ Code = "022", Description = "���������� ���������, ������ �� ������� �������. ����������"},
                        new UDC{ Code = "023", Description = "���������� ������ �������. �����. �������� �������"},
                        new UDC{ Code = "024", Description = "³������� � �������� (��������������). ����������� ������������� ���������"},
                        new UDC{ Code = "025", Description = "������������ ����� �������� (���������� �����, ��������-������������ ������, �����������)"},
                        new UDC{ Code = "026", Description = "������� �� ��������� ��������"},
                        new UDC{ Code = "027", Description = "���������� ��������"},
                        new UDC{ Code = "028", Description = "������� (��������� �������, ������ �� ������ �������)"},
                    new UDC{ Code = "030", Description = "������� ������� ���������� ���� (���������䳿, ��������)"},
                    new UDC{ Code = "050", Description = "����� ���������. �������� (��������, ���������, ��������)"},
                    new UDC{ Code = "06", Description = "���������� �� ���� ���� ��'������� (�������������)"},
                    new UDC{ Code = "070", Description = "������. �����"},
                    new UDC{ Code = "08", Description = "������� �������� �����. �����. �������"},
                        new UDC{ Code = "087.5", Description = "�������-��������� ��������� ��� ����"},
                    new UDC{ Code = "09", Description = "��������. �������� �� ����� �������"},
                        new UDC{ Code = "091", Description = "��������"},
                        new UDC{ Code = "092", Description = "������������ �����"},
                        new UDC{ Code = "093", Description = "����������"},
                        new UDC{ Code = "094", Description = "���� �������, ���������� ���������, ����������� ��������"},
                        new UDC{ Code = "095", Description = "����� � ������������ ����������"},
                        new UDC{ Code = "096", Description = "����� � ��������� ������������ ��� ������������� ������� ����������"},
                        new UDC{ Code = "097", Description = "����� � ������� ��������"},
                        new UDC{ Code = "098", Description = "г�� ���� ���� � ��������� ����������������"},
                        new UDC{ Code = "099", Description = "���� ����� � ��������� �������� ��������. г����, ��������� �����"},

                new UDC{ Code = "1", Description = "Գ�������. ���������"},
                    new UDC{ Code = "101", Description = "������� � ���� ���������"},
                    new UDC{ Code = "11", Description = "����������"},
                    new UDC{ Code = "12", Description = "����� �������� �� ������� ���������"},
                    new UDC{ Code = "13", Description = "Գ������� ������ �� ����. ���������� ��������� �����"},
                    new UDC{ Code = "14", Description = "Գ�������� ������� �� �������"},
                    new UDC{ Code = "159.9", Description = "���������"},
                    new UDC{ Code = "16", Description = "�����. �����������. ����� �������. ���������� �����"},
                    new UDC{ Code = "17", Description = "Գ������� �����. �����. ��������� ���������"},

                new UDC{ Code = "2", Description = "�����. ������� (��������'�)"},
                    new UDC{ Code = "21", Description = "�������� �������. ��������. ���. ����������� �������. ������� ���������"},
                    new UDC{ Code = "22", Description = "�����. ����� ������"},
                    new UDC{ Code = "23", Description = "���������� �������"},
                    new UDC{ Code = "24", Description = "��������� �������"},
                    new UDC{ Code = "25", Description = "���������� ������� (��������'�)"},
                    new UDC{ Code = "26", Description = "������������ ������ � ������"},
                    new UDC{ Code = "27", Description = "�������� ������ ������������ ������"},
                    new UDC{ Code = "28", Description = "����������� ������, �����, ����������"},
                    new UDC{ Code = "29", Description = "������������� ���㳿"},

                new UDC{ Code = "3", Description = "������� �����"},
                    new UDC{ Code = "30", Description = "�����, ���������� �� ������ ��������� ����. �����������"},

                    new UDC{ Code = "31", Description = "����������, ���������, ����������"},
                        new UDC{ Code = "311", Description = "���������� �� �����. ����� ����������"},
                        new UDC{ Code = "314", Description = "����������. �������� ���������������"},
                        new UDC{ Code = "316", Description = "���������"},

                    new UDC{ Code = "32", Description = "�������"},
                        new UDC{ Code = "321", Description = "����� �������� ����������. ������� �� �������� �����"},
                        new UDC{ Code = "322", Description = "³������� �� ������� �� ��������. ������� �������� ���㳿. �������� �������"},
                        new UDC{ Code = "323", Description = "������� ������. �������� �������"},
                        new UDC{ Code = "324", Description = "������. ���������. �����������. ������� ������. ��������, ����������� �� ��� ������. ���������� ������"},
                        new UDC{ Code = "325", Description = "�������� ����� ��������. ����������"},
                        new UDC{ Code = "326", Description = "�������"},
                        new UDC{ Code = "327", Description = "̳������� ��'����. ������ �������. ̳������� ������. ������� �������"},
                        new UDC{ Code = "328", Description = "����������. �������������� ������. �����"},
                        new UDC{ Code = "329", Description = "������� ���� �� ����"},

                    new UDC{ Code = "33", Description = "��������. ��������� �����"},
                        new UDC{ Code = "330", Description = "�������� � ������"},
                        new UDC{ Code = "331", Description = "�����. ����������������. ������. �������� �����. ���������� �����"},
                        new UDC{ Code = "332", Description = "���������� ��������. ������������ ��������. �������� ����. �������� �����"},
                        new UDC{ Code = "334", Description = "����� ���������� �� ������������� � ��������"},
                        new UDC{ Code = "336", Description = "Գ�����"},
                        new UDC{ Code = "338", Description = "��������� ���������. ��������� �������. ��������� �� ���������� � ��������. �����������. �������. ֳ��"},
                        new UDC{ Code = "339", Description = "�������. ̳������� �������� ��������. ������ ��������"},
                            new UDC{ Code = "339.1", Description = "������� ������� ������. �����"},
                            new UDC{ Code = "339.3", Description = "�������� �������"},
                            new UDC{ Code = "339.5", Description = "������� �������. ̳�������� �������"},
                            new UDC{ Code = "339.7", Description = "̳������� �������"},
                            new UDC{ Code = "339.9", Description = "̳�������� �������� � ������. ̳������� �������� ��'����. ������ ������������"},

                    new UDC{ Code = "34", Description = "�����. �������������"},
                        new UDC{ Code = "340", Description = "����� � ������. ������������. ������ �� ������� �������� �����"},
                        new UDC{ Code = "341", Description = "̳�������� �����"},
                        new UDC{ Code = "342", Description = "�������� �����. ������������� �����. ������������� �����"},
                        new UDC{ Code = "343", Description = "���������� �����. ���� ���������"},
                        new UDC{ Code = "344", Description = "������� ���� ������������ �����. ³�������, ��������-�������, ��������-�������� �����"},
                        new UDC{ Code = "346", Description = "������������ �����. ������ ������ ���������� ����������� ��������"},
                        new UDC{ Code = "347", Description = "������� �����. ������� �����"},
                        new UDC{ Code = "349.2", Description = "������� �����"},
                        new UDC{ Code = "349.3", Description = "����� ����������� ������������"},
                        new UDC{ Code = "349.4", Description = "�������� �����. ����� ���������� ��������� ������"},
                        new UDC{ Code = "349.6", Description = "������ �������� ������� ������������� ����������"},
                        new UDC{ Code = "349.7", Description = "������ �����"},

                    new UDC{ Code = "35", Description = "�������� ������������� ���������. ³������� ������"},
                        new UDC{ Code = "351", Description = "������� �������� ������ ���������� ��������������� ���������"},
                        new UDC{ Code = "352", Description = "����� ����� ������ ���������. ������ �������� ���������. ����������� �����������. ̳���� ������"},
                        new UDC{ Code = "353", Description = "������� ����� ������ ���������. ����������, ���������� ���������. ��������� ������"},
                        new UDC{ Code = "354", Description = "�����, �������� ����� ������ ���������. ����������, �������� ���������"},
                        new UDC{ Code = "355", Description = "³������� ������ � ������"},
                        new UDC{ Code = "356", Description = "ϳ����"},
                        new UDC{ Code = "357", Description = "��������. ʳ�� ������. ����������� ������. ³�������-���������� �������"},
                        new UDC{ Code = "358", Description = "��������. ����������� ������. �������� ������. ³������� ������. г�� ������ ������ �� �� �������"},
                        new UDC{ Code = "359", Description = "³�������-������ ����. ³�������-�������� ����. �������� �����, ����������"},

                    new UDC{ Code = "36", Description = "������������ �������� � ����������� ������� ������"},
                        new UDC{ Code = "364", Description = "�������� ��������, �� ���������� ����������� ������� ��������� ��������. ���� ��������� ��������"},
                        new UDC{ Code = "365", Description = "������� � ���� �� �� �����������. ������������ ������"},
                        new UDC{ Code = "366", Description = "���'�������. ��� �� ������ �������� �� ���� ����������"},
                        new UDC{ Code = "368", Description = "�����������. �������� ������������ ������ �������� �������� ������"},
                        new UDC{ Code = "369", Description = "��������� �����������"},

                    new UDC{ Code = "37", Description = "�����. ���������. ��������. �������"},
                        new UDC{ Code = "37.0", Description = "������ ���� �� �������� �����"},
                        new UDC{ Code = "371", Description = "���������� ������� ����� �� ���������. ������ ����������"},
                        new UDC{ Code = "372", Description = "���� �� ����� �������� � ���������� �������� �� ����������� �������. �������� ��� ���� �������� �� ���� ��� (��������)"},
                        new UDC{ Code = "373", Description = "���� �������������� ���"},
                        new UDC{ Code = "374", Description = "���������� ����� � ���������. �������� ����� (���������)"},
                        new UDC{ Code = "376", Description = "�����, ��������, ��������� ����������� ���� ���. ��������� �����"},
                        new UDC{ Code = "377", Description = "������������� ��������. ���������-������� ��������. �������� ������. ���������� �����"},
                        new UDC{ Code = "378", Description = "���� �����. �����������. ϳ�������� �������� �����"},
                        new UDC{ Code = "379.8", Description = "�������"},

                    new UDC{ Code = "39", Description = "��������. ����������. �����. ��������. ����� �����. ��������"},
                        new UDC{ Code = "391", Description = "�������� ����. ������ �������. ������������ ����. ������ ��������. ����"},
                        new UDC{ Code = "392", Description = "�����, �������� � ���������� ����"},
                        new UDC{ Code = "393", Description = "������. ���������� � ���������. ���������. ������, ���'���� � �����������"},
                        new UDC{ Code = "394", Description = "���������� �����. ����� ������"},
                        new UDC{ Code = "395", Description = "���������. ������. ������� ��������. �������� ��������. ������. ������"},
                        new UDC{ Code = "396", Description = "������. Ƴ��� � ����������. ��������� ����"},
                        new UDC{ Code = "397", Description = "������ ������. ����� ����, ������� � ����� ���� �� ������"},
                        new UDC{ Code = "398", Description = "�������� � �������� �������"},


                new UDC{ Code = "5", Description = "����������. ���������� �����"},
                    new UDC{ Code = "50", Description = "������� ������� ��� ���������� �� ���������� �����"},
                        new UDC{ Code = "501", Description = "������� ������� ��� ���� �����. ���������� ����� � ������, ��������� ���������, �������, ����������� ������"},
                        new UDC{ Code = "502", Description = "�������. ���������� ������� �� �� ����������. ������ ������������� ���������� (�������) �� ���� �������"},
                        new UDC{ Code = "504", Description = "����� ��� ��������� ����������. �������"},

                    new UDC{ Code = "51", Description = "����������"},
                        new UDC{ Code = "510", Description = "������������� �� ������� ������� ����������"},
                        new UDC{ Code = "511", Description = "����� �����"},
                        new UDC{ Code = "512", Description = "�������"},
                        new UDC{ Code = "514", Description = "��������"},
                        new UDC{ Code = "515.1", Description = "N�������"},
                        new UDC{ Code = "517", Description = "�����"},
                        new UDC{ Code = "519.1", Description = "������������ �����. ����� ������"},
                        new UDC{ Code = "519.2", Description = "���������. ����������� ����������"},
                        new UDC{ Code = "519.6", Description = "������������� ����������"},
                        new UDC{ Code = "519.7", Description = "����������� ����������"},
                        new UDC{ Code = "519.8", Description = "���������� ��������"},

                    new UDC{ Code = "52", Description = "���������. �����������. ������ ����������. �������"},
                        new UDC{ Code = "520", Description = "�����������, ������� �� ������ ������������ ���������"},
                        new UDC{ Code = "521", Description = "���������� ���������. ������� �������"},
                        new UDC{ Code = "523", Description = "������� �������"},
                        new UDC{ Code = "524", Description = "���. ����� �������. ������"},
                        new UDC{ Code = "527", Description = "��������� �� �������� ���������. ��������"},
                        new UDC{ Code = "528", Description = "�������. ���������-��������� ������. �������������. ����������� ����������."},

                    new UDC{ Code = "53", Description = "Գ����"},
                            new UDC{ Code = "530.1", Description = "������ ������ (��������) ������"},
                        new UDC{ Code = "531", Description = "�������� �������. ������� ������� �� �������� ��"},
                        new UDC{ Code = "532", Description = "������� ������� ������� ����. ������� ���� (�����������)"},
                        new UDC{ Code = "533", Description = "������� ����. �����������. Գ���� ������"},
                        new UDC{ Code = "534", Description = "������� ���������. ��������"},
                        new UDC{ Code = "535", Description = "������"},
                        new UDC{ Code = "536", Description = "�������. ������������"},
                        new UDC{ Code = "537", Description = "���������. ���������. ����������������"},
                            new UDC{ Code = "538.9", Description = "Գ���� ������������ ����� (� �������� � �������� ����)"},
                        new UDC{ Code = "539", Description = "Գ����� ����� �����"},

                    new UDC{ Code = "54", Description = "ճ��. ��������������. ̳��������"},
                        new UDC{ Code = "542", Description = "��������� ����������� ����. ������������ �� ���������������� ����"},
                        new UDC{ Code = "543", Description = "��������� ����"},
                        new UDC{ Code = "544", Description = "Գ����� ����"},
                        new UDC{ Code = "546", Description = "���������� ����"},
                        new UDC{ Code = "547", Description = "�������� ����"},
                        new UDC{ Code = "548", Description = "��������������"},
                        new UDC{ Code = "549", Description = "̳��������. ���������� ��������������"},

                    new UDC{ Code = "55", Description = "�������. ����� ��� �����"},
                        new UDC{ Code = "550", Description = "������� �������� �����"},
                        new UDC{ Code = "551", Description = "�������� �������. �����������. ����������. ��������� �������. ������������. ��������������"},
                        new UDC{ Code = "552", Description = "���������. �����������"},
                        new UDC{ Code = "553", Description = "��������� �������. �������� �������� �������"},
                        new UDC{ Code = "556", Description = "ó��������. ���� � ������. ó�������"},

                    new UDC{ Code = "56", Description = "������������"},
                        new UDC{ Code = "561", Description = "������������. ����������� �������� ������"},
                        new UDC{ Code = "562", Description = "���������� � ������"},
                        new UDC{ Code = "564", Description = "�������. �'�����. ���������"},
                        new UDC{ Code = "565", Description = "�������"},
                        new UDC{ Code = "567", Description = "����"},
                        new UDC{ Code = "568", Description = "����������. ����������"},
                        new UDC{ Code = "569", Description = "������"},

                    new UDC{ Code = "57", Description = "�������� ����� � ������"},
                        new UDC{ Code = "572", Description = "�����������"},
                        new UDC{ Code = "573", Description = "�������� �� ���������� ������"},
                        new UDC{ Code = "574", Description = "�������� �������"},
                        new UDC{ Code = "575", Description = "�������� ��������. �������� ������������"},
                        new UDC{ Code = "576", Description = "������� �� ���������� ������. ��������"},
                        new UDC{ Code = "577", Description = "��������� ������ �����. �������. ����������� ������. ���������"},
                        new UDC{ Code = "578", Description = "³��������"},
                        new UDC{ Code = "579", Description = "̳���������"},


                    new UDC{ Code = "58", Description = "�������"},
                        new UDC{ Code = "581", Description = "�������� �������"},
                        new UDC{ Code = "582", Description = "����������� ������"},

                    new UDC{ Code = "59", Description = "�������"},
                        new UDC{ Code = "591", Description = "�������� �������"},
                        new UDC{ Code = "592", Description = "����������"},
                        new UDC{ Code = "594", Description = "�������"},
                        new UDC{ Code = "595", Description = "�������"},
                        new UDC{ Code = "598", Description = "����������"},
                        new UDC{ Code = "599", Description = "������"},


                new UDC{ Code = "6", Description = "�������� �����. ��������. ������. ѳ������ ������������"},
                    new UDC{ Code = "60", Description = "������� ������� ���������� ����"},

                    new UDC{ Code = "61", Description = "������ �����"},

                        new UDC{ Code = "613", Description = "ó㳺�� � ������. �������� ������'� �� �㳺��"},
                        new UDC{ Code = "614", Description = "�������� ������'� �� �㳺��. ������������ �������� �������"},
                        new UDC{ Code = "615", Description = "�����������. ������. �����������"},
                        new UDC{ Code = "616", Description = "��������. ������ ��������"},
                            new UDC{ Code = "616.1", Description = "�������� �������-������� ������� �� ����"},
                            new UDC{ Code = "616.2", Description = "�������� �������� �������. ������������, ���'���� � �������� �������"},    
                            new UDC{ Code = "616.3", Description = "�������� ������ �������. ������� ������ �������"},    
                            new UDC{ Code = "616.4", Description = "�������� ��������� �������, ������������ (������������) ������, ����������� ������"},    
                            new UDC{ Code = "616.5", Description = "����. ��������� ������ ������ ���. ������ �����������"},    
                            new UDC{ Code = "616.6", Description = "�������� ����������� �������. ������� ������ �� ������� ������"},    
                            new UDC{ Code = "616.7", Description = "�������� ������ ����, �����������. �������� �� ������ �������"},    
                            new UDC{ Code = "616.8", Description = "���������. �������������. ������� �������"},    
                            new UDC{ Code = "616.9", Description = "�������� ������������. ��������� �� ������ ������������, �������"},    
                        new UDC{ Code = "617", Description = "ճ�����. ��������. ������������"},
                        new UDC{ Code = "618", Description = "ó��������. ����������"},
                        new UDC{ Code = "619", Description = "����������� ��������"},

                    new UDC{ Code = "62", Description = "���������������. ������ � ������"},
                        new UDC{ Code = "620", Description = "������������ ��������. �������� ������������ ��������. ��������������. ����������������"},
                        new UDC{ Code = "621", Description = "�������� ���������������. ������ ������. �������������. ��������������� � ������"},
                        new UDC{ Code = "622", Description = "ó����� ������"},
                        new UDC{ Code = "624", Description = "���������� ���������� ������ �� �������� ����������� � ������"},
                        new UDC{ Code = "625", Description = "������� ����������. ���������� ��������. ���������� ������������ ����"},
                        new UDC{ Code = "628", Description = "�������� ������. ��������������. ��������� � ����������. ������������ ������"},
                        new UDC{ Code = "629", Description = "���������"},

                    new UDC{ Code = "63", Description = "ѳ������ ������������. ˳���� ������������. ����������. ����� ������������"},
                        new UDC{ Code = "630", Description = "˳���� ������������. ˳��������"},
                        new UDC{ Code = "631", Description = "������� ������� ��������� ������������"},
                            new UDC{ Code = "631.1", Description = "���������� �� ��������� �������� �������������"},
                            new UDC{ Code = "631.2", Description = "ѳ����������������� �����, ������� (������������ ����������). ����� ��� �������� ������, ���������, ��������� ������������"},
                            new UDC{ Code = "631.2", Description = "ѳ����������������� ������, �������� �� �����������"},
                            new UDC{ Code = "631.4", Description = "��������������. ������� ����������"},
                            new UDC{ Code = "631.5", Description = "ѳ����������������� ������. ����������"},
                            new UDC{ Code = "631.6", Description = "ѳ������������������ ���������"},
                            new UDC{ Code = "631.8", Description = "�������. ���������� ��������� � ����������� ������. ������������ ����� ������. ������ ��������. ������� �����������"},   

                        new UDC{ Code = "632", Description = "������� ������. ������� ������. ������ ������"},
                            new UDC{ Code = "632.1", Description = "������������ �������. ������� ������� ������������ ����������"},
                            new UDC{ Code = "632.2", Description = "�������������� ������"},
                            new UDC{ Code = "632.3", Description = "���������� �� ����� ������� ������"},
                            new UDC{ Code = "632.4", Description = "������� ������� ������"},
                            new UDC{ Code = "632.5", Description = "������ ������� (����� ������ ��� ����� ������)"},
                            new UDC{ Code = "632.6", Description = "������� � ������� ������ (��� �����)"},
                            new UDC{ Code = "632.7", Description = "������ � ������� ������"},
                            new UDC{ Code = "632.8", Description = "���� ������� �� ������� ������"},
                            new UDC{ Code = "632.9", Description = "�������� � ��������� ������ �� ��������� ������"},
                        new UDC{ Code = "633", Description = "г��������. ������ ������������������ �������� �� �� �����������"},
                            new UDC{ Code = "633.1", Description = "���� �����. ������ ��������"},
                            new UDC{ Code = "633.2", Description = "������ �����. ����� �� �������� �����"},
                            new UDC{ Code = "633.3", Description = "������ ������� (��� �����)"},
                            new UDC{ Code = "633.4", Description = "������ ����������� �� ������. �����������"},
                            new UDC{ Code = "633.5", Description = "�������� �� ��������� ��������"},
                            new UDC{ Code = "633.6", Description = "������ �� ��������� �������"},
                            new UDC{ Code = "633.7", Description = "��������� � ��������� �������. �������, �� ���������������� � ���������� �����"},
                            new UDC{ Code = "633.8", Description = "��������� (���������) �������. �������-��������. ���� �������. �������� �������. ������� �������. ˳������ �������"},
                            new UDC{ Code = "633.9", Description = "���� ������� ������������ ������������"},
                        new UDC{ Code = "634", Description = "���������� � ������. �����������"},
                            new UDC{ Code = "634.1", Description = "����������� � ������"},
                            new UDC{ Code = "634.2", Description = "ʳ������� ����� � ������"},
                            new UDC{ Code = "634.3", Description = "����� (��������� ��������). ��������� (�����). ������� �������"},
                            new UDC{ Code = "634.4", Description = "���� ������"},
                            new UDC{ Code = "634.5", Description = "�����������"},
                            new UDC{ Code = "634.6", Description = "г�������� ������ �� ��������� ������"},
                            new UDC{ Code = "634.7", Description = "������� ����� ����� �� ����'���� ������. ���� ��������"},
                            new UDC{ Code = "634.8", Description = "��������������. �������� ����� ���������. ������������"},
                        new UDC{ Code = "635", Description = "������������ � ����������� ����������"},
                            new UDC{ Code = "635.1", Description = "������ (������) �����������"},
                            new UDC{ Code = "635.2", Description = "������ ����������� �� ��������"},
                            new UDC{ Code = "635.3", Description = "������� � �������� ��������, ������ ��� �������"},
                            new UDC{ Code = "635.4", Description = "���� ����� ������ ��������. ������ ������"},
                            new UDC{ Code = "635.5", Description = "������ �������. ������ �����"},
                            new UDC{ Code = "635.6", Description = "������� � �������� ������� �� �������. ����� ��������"},
                            new UDC{ Code = "635.7", Description = "���������, ������ �����. ���� �������"},
                            new UDC{ Code = "635.8", Description = "�����"},
                            new UDC{ Code = "635.9", Description = "���������� �������. ����������� ����������"},
                        new UDC{ Code = "636", Description = "������� ������� ������������. ���������� ������ � ������. ����������. ������ ������� �� �� ����������"},
                            new UDC{ Code = "636.1", Description = "���������� (�������������) �������. ������ ���. ��� �����, ������� ���"},
                            new UDC{ Code = "636.2", Description = "������ ������ ������"},
                            new UDC{ Code = "636.3", Description = "��� ���� �������. ���� ������ ������. ³���. ����"},
                            new UDC{ Code = "636.4", Description = "����"},
                            new UDC{ Code = "636.5", Description = "������ �����"},
                            new UDC{ Code = "636.6", Description = "����� (��� ������� �� ���������� ������), �� ��������� ��� ��������� ����"},
                            new UDC{ Code = "636.7", Description = "������"},
                            new UDC{ Code = "636.8", Description = "ʳ���"},
                            new UDC{ Code = "636.9", Description = "���� �������, ���� ��������� ����"},
                        new UDC{ Code = "637", Description = "�������� ������������"},
                            new UDC{ Code = "637.1", Description = "������� ������������ � ������"},
                            new UDC{ Code = "637.2", Description = "����� �� ������������"},
                            new UDC{ Code = "637.3", Description = "��� �� �����������"},
                            new UDC{ Code = "637.4", Description = "����. �������� ��������� ����"},
                            new UDC{ Code = "637.5", Description = "�'���. ��� �'��� ������ ��������"},
                            new UDC{ Code = "637.6", Description = "���� �������� ��������� (��� �������)"},
                        new UDC{ Code = "638", Description = "������, ��������� � ���������� ����� �� ����� �������������"},
                            new UDC{ Code = "638.1", Description = "�����������. ��������� ����"},
                            new UDC{ Code = "638.2", Description = "���������� ������������ ����������. �����������"},
                            new UDC{ Code = "638.3", Description = "������ �������"},
                            new UDC{ Code = "638.4", Description = "���������, ���������� ����� �����"},
                            new UDC{ Code = "638.5", Description = "���������� ������������� �����"},
                            new UDC{ Code = "638.8", Description = "��������� ����� � ������������ �����"},
                        new UDC{ Code = "639", Description = "���������, ����������. ����� ������������. ����������"},
                            new UDC{ Code = "639.1", Description = "���������"},
                            new UDC{ Code = "639.2", Description = "���������. ���������� � ���� ��������"},
                            new UDC{ Code = "639.3", Description = "��������������. ���������"},
                            new UDC{ Code = "639.4", Description = "���������� ������� �������"},
                            new UDC{ Code = "639.5", Description = "���������� �����������, �������� �����, �'���� ����"},
                            new UDC{ Code = "639.6", Description = "���� ������������"},

                        new UDC{ Code = "64", Description = "�����������. ���������� ������������. ������ ������"},
                            new UDC{ Code = "640", Description = "���� ����������-��������� ��������� �� ������ ������������"},
                            new UDC{ Code = "641", Description = "�������� ����������. ������������ ��. ������"},
                            new UDC{ Code = "642", Description = "��� �� �������� ��. �������� �����"},
                            new UDC{ Code = "643", Description = "�����. ����������"},
                            new UDC{ Code = "644", Description = "��������-������� ���������� ���������"},
                            new UDC{ Code = "645", Description = "�������� ���������� ����"},
                            new UDC{ Code = "646", Description = "����. �������� �㳺��"},
                            new UDC{ Code = "647", Description = "������������� �������� � ���������� �� ����������-���������� �����������"},
                            new UDC{ Code = "648", Description = "������. ������. ������. ���������� ��������"},
                            new UDC{ Code = "649", Description = "������ �� �����, �������, ��������� �� ������ ������"},
                        new UDC{ Code = "65", Description = "��������� ������������. ����������. ���������� �����������, ������, ����������, ��'����, ���������"},
                            new UDC{ Code = "651", Description = "���������� (������������) ������. ����-����������. ĳ���������. ���������"},
                            new UDC{ Code = "654", Description = "���������'���� (���������� �� ������������)"},
                            new UDC{ Code = "655", Description = "����������� ������������. ���������� ����������. �����������. �������� �������"},
                            new UDC{ Code = "656", Description = "���������� �� ������ ������. ���������� �� ��������� �������������"},
                            new UDC{ Code = "657", Description = "����������. �������������� ����. �����������"},
                            new UDC{ Code = "658", Description = "���������� �����������, ����������. �������� ���������. ���������� �� ������ ������"},
                            new UDC{ Code = "659", Description = "�������. ������� ����������. ������ �������� ���������� �� ������� (������ �������)"},
                        new UDC{ Code = "66", Description = "ճ���� ���������. ճ���� ������������ � �������� �����"},
                            new UDC{ Code = "661", Description = "�������� ������ ������������"},
                            new UDC{ Code = "662", Description = "������� ��������. ������"},
                            new UDC{ Code = "663", Description = "���������� ����������. ���������� �������. ��������� �����������, ������������ ��������. ����������� �����. ����������� �������� �����"},
                            new UDC{ Code = "664", Description = "������� ������������ � ������. ����������� � ������������� �������� ��������"},
                            new UDC{ Code = "665", Description = "�볿. ����. ³��. ���. �����. �����"},
                            new UDC{ Code = "666", Description = "������ � �������� ������������. ������������ �'������. ������ � �����"},
                            new UDC{ Code = "667", Description = "����������� ������������"},
                            new UDC{ Code = "669", Description = "���������"},
                        new UDC{ Code = "67", Description = "г�� ����� ������������ �� �������"},
                            new UDC{ Code = "671", Description = "������ � ������������ ������ �� ���������� ������"},
                            new UDC{ Code = "672", Description = "������ � ����� �� ���� � ������"},
                            new UDC{ Code = "673", Description = "������ � ���������� ������ (�� �������� ������������ ������)"},
                            new UDC{ Code = "674", Description = "������������� ������������"},
                            new UDC{ Code = "675", Description = "������ ������������ (��������� ����������� ����� � ������ ����)"},
                            new UDC{ Code = "676", Description = "���������-�������� ������������"},
                            new UDC{ Code = "677", Description = "���������� ������������"},
                            new UDC{ Code = "678", Description = "������������ ������������������ �������. ����������� ����. ����������� ��������"},
                            new UDC{ Code = "679", Description = "����� ������������ � ��������� ����� ��������"},
                        new UDC{ Code = "68", Description = "����� ������������ �� �������, �� ���������� ������ ���������"},
                            new UDC{ Code = "681", Description = "����� ������� �� ����������"},
                            new UDC{ Code = "682", Description = "���������� ������. ϳ���������� ������. ������������ ������� ������"},
                            new UDC{ Code = "683", Description = "����� ������. �������� ������. ����� � �������� ����������. ����"},
                            new UDC{ Code = "684", Description = "������� ������������"},
                            new UDC{ Code = "685", Description = "����������� �����-�������� �� ����� ������ �� ����. ������� �����������. ����������� ������������ �� ����������� ���������"},
                            new UDC{ Code = "686", Description = "�������������-�������� �����������. ��������. ��������. ����������� �������. ����������� ��������"},
                            new UDC{ Code = "687", Description = "������ ������������. ����������� ����������� ������"},
                            new UDC{ Code = "688", Description = "����������� �� ���������� ������. �������"},
                            new UDC{ Code = "689", Description = "������ �� ���� ��������� ���� ������"},
                        new UDC{ Code = "69", Description = "��������� ������������. �������� ��������. ���������-������� ������"},
                            new UDC{ Code = "691", Description = "�������� �������� �� ����������"},
                            new UDC{ Code = "692", Description = "������������� ������� �� �������� �����"},
                            new UDC{ Code = "693", Description = "���'��� ��� ������� ������ �� ���'���� � ��� �������� ������"},
                            new UDC{ Code = "694", Description = "�����'�� �����������. ������������� �����������. ������� ������"},
                            new UDC{ Code = "696", Description = "��������-�������, ������, ������, ���������� ���������� ������� �� ���� ������"},
                            new UDC{ Code = "697", Description = "���������, ���������� �� ������������� ������ � �������"},
                            new UDC{ Code = "698", Description = "������������ �� ���������� ������"},
                            new UDC{ Code = "699.8", Description = "������ ������ �������� �� ���� �������. ����������� ������"},


                new UDC{ Code = "7", Description = "���������. �����������. ����. �����"},
                    new UDC{ Code = "71", Description = "���������� � ����� �������������-������������� �������. ���������, �����, ����"},
                        new UDC{ Code = "711", Description = "�������� �� �������� ����������. ���������� � ����� �������������-������������� �������"},
                        new UDC{ Code = "712", Description = "���������� ����������� (�������� �� ������������). �����. ����, ������"},
                        new UDC{ Code = "718", Description = "���������. ��������. ���� ���� ��������� �������� (����������, ����������, ������ ����)"},
                        new UDC{ Code = "719", Description = "������� �������� � ������ ���������� � ���������� ���'����"},
                    new UDC{ Code = "72", Description = "�����������"},
                        new UDC{ Code = "721", Description = "����� � ������"},
                        new UDC{ Code = "725", Description = "�������, ���������, ������, ��������� �����. ������� ����������� � ������"},
                        new UDC{ Code = "726", Description = "������� ������� �� �����. ������� �� ���������� �����"},
                        new UDC{ Code = "727", Description = "����� ������, �������� �� ���������-������ ������"},
                        new UDC{ Code = "728", Description = "������� �����������. ������� ����������. �����"},
                    new UDC{ Code = "73", Description = "�������� ���������"},
                        new UDC{ Code = "730", Description = "���������� � ������"},
                        new UDC{ Code = "736", Description = "�������. ����������"},
                        new UDC{ Code = "737", Description = "����������"},
                        new UDC{ Code = "739", Description = "������� ������� ������"},
                    new UDC{ Code = "74", Description = "��������� �� ���������. ������. �����������-��������� ���������. ������ ��������"},
                        new UDC{ Code = "741", Description = "��������� �� ��������� � ������"},
                        new UDC{ Code = "742", Description = "����������� � �������� �� ����������"},
                        new UDC{ Code = "743", Description = "��������� ���������"},
                        new UDC{ Code = "744", Description = "����������� ���������. ������� ���������"},
                        new UDC{ Code = "746", Description = "��������. ������ ���������"},
                        new UDC{ Code = "747", Description = "���������� �����'���"},
                        new UDC{ Code = "748", Description = "��������� ������� ������. ������ ������ � ���� �� ��������"},
                        new UDC{ Code = "749", Description = "������ ����, ������� �������� �� ���������"},
                    new UDC{ Code = "75", Description = "�������"},
                    new UDC{ Code = "76", Description = "������� ���������. �������"},
                        new UDC{ Code = "761", Description = "������� �������� �����"},
                        new UDC{ Code = "762", Description = "������� ��������� �����"},
                        new UDC{ Code = "763", Description = "������� �������� �����"},
                        new UDC{ Code = "766", Description = "��������� �������. �������� �������"},
                        new UDC{ Code = "769", Description = "���� ������"},
                    new UDC{ Code = "77", Description = "����������, ������������� �� ����� �������"},
                        new UDC{ Code = "771", Description = "������������ ����������, ������� �� ��������"},
                        new UDC{ Code = "772", Description = "����������� �������, ��� ������� � ������������� ����������� ������� ��� �������� ����"},
                        new UDC{ Code = "773", Description = "����������� �������, ��� ������� � ������������� ��������� ������"},
                        new UDC{ Code = "774", Description = "����������� ������� � ������"},
                        new UDC{ Code = "776", Description = "�������������. ����������� ������� ������������ ����������� ���� ��� �������� �����"},
                        new UDC{ Code = "777", Description = "����� ��������� �����. �����������. ����� �������� ����� (������� �� �������)"},
                        new UDC{ Code = "778", Description = "��������� ����� ������������ �� ����������"},
                    new UDC{ Code = "78", Description = "������"},
                        new UDC{ Code = "781", Description = "����� ������. ������� �������"},
                        new UDC{ Code = "782", Description = "���������� ������. �����"},
                        new UDC{ Code = "783", Description = "�������� ������. ������� ������. ������� ������"},
                        new UDC{ Code = "784", Description = "�������� ������. ����"},
                        new UDC{ Code = "785", Description = "��������������� ������. ��������� ������. ������ ��� ��������. ������ ��� ��������"},
                        new UDC{ Code = "786", Description = "������ ��� �������� �����������"},
                        new UDC{ Code = "787", Description = "������ ��� ��������� �� �������� �����������"},
                        new UDC{ Code = "788", Description = "������ ��� ������� �����������"},
                        new UDC{ Code = "789", Description = "������ ��� ������� �����������. ������ ��� ��������� �������� �����������"},
                    new UDC{ Code = "79", Description = "�������� ���������. �������. ����. �����"},
                        new UDC{ Code = "791", Description = "����� �������. �������. ��������"},
                        new UDC{ Code = "792", Description = "�����. ������� ���������. ��������� �������"},
                        new UDC{ Code = "793", Description = "³�������� �� ������� ������������. ��������� ����. �����"},
                        new UDC{ Code = "794", Description = "������� ���� (�� ���������, ��������� �� �����)"},
                        new UDC{ Code = "796", Description = "�����. ����. Գ���� ������"},
                        new UDC{ Code = "797", Description = "������ �����. ��������� �����"},
                        new UDC{ Code = "798", Description = "ʳ���� ����� �� ������� ����. �������� �������� �� ����� �� ����� ��������"},
                        new UDC{ Code = "799", Description = "��������� ����������. ��������� ����������. ��������� ������� �� �����"},

                new UDC{ Code = "8", Description = "����. ������������. ������� ���������. ˳����������������"},
                    new UDC{ Code = "80", Description = "������� ������� ��������� �� ���������. Գ������"},
                        new UDC{ Code = "801", Description = "�������. ³��������. ������� ����� �� ������� ������㳿"},
                        new UDC{ Code = "808", Description = " ��������. ��������� ������������ ����"},
                    new UDC{ Code = "81", Description = "˳��������. ������������. ����"},
                    new UDC{ Code = "82", Description = "������� ���������. ˳����������������"},

                new UDC{ Code = "9", Description = "���������. ���������. ������"},
                    new UDC{ Code = "90", Description = ""}, //!
                        new UDC{ Code = "902", Description = "���������"},
                        new UDC{ Code = "903", Description = "����������. ��������� �������. �������� �����. ������������"},
                        new UDC{ Code = "904", Description = "���������� ���'���� ���������� ����"},
                        new UDC{ Code = "908", Description = "�����������"},
                    new UDC{ Code = "91", Description = "���������. ���������� ���������� ���� �� ������� ����."},
                    new UDC{ Code = "92", Description = ""}, //!
                        new UDC{ Code = "929", Description = "���������� �� ����� ����������"},
                    new UDC{ Code = "93", Description = "������"},
                        new UDC{ Code = "930", Description = "��������� �����"},
                    new UDC{ Code = "94", Description = "�������� ������"},
            };
            UDCs.ForEach(u => context.UDCs.AddOrUpdate(t => t.Code, u));
            context.SaveChanges();

            List<Book> books = new List<Book>
            {
                new Book
                {
                    Name = "������� ����� �� ����� ��������������� �������",
                    Publishing = "���������, 22-� �������",
                    EditionYear = 2001,
                    Pages = 432,
                    UDCID = context.UDCs.First(u=>u.Code=="517").ID
                    /*UDC = "TBD",
                    AuthorsList = new List<Author> {context.Authors.FirstOrDefault(a => a.LastName == "������")}*/
                },
                new Book
                {
                    Name = "������� ����� � ���������� �� ��������������� �������",
                    Publishing = "�����, 13 �������",   
                    EditionYear = 1997,
                    Pages = 624,
                    UDCID = context.UDCs.First(u=>u.Code=="517").ID
                    /*UDC = "TBD",
                    AuthorsList = new List<Author> {context.Authors.FirstOrDefault(a => a.LastName == "���������")},*/
                }
            };
            books.ForEach(b => context.Books.AddOrUpdate(t => t.Name, b));
            context.SaveChanges();


            List<BookCopy> bookCopies = new List<BookCopy>
            {
                new BookCopy{BookID = books.Single(b=>b.Name=="������� ����� �� ����� ��������������� �������").ID, StatusID = statuses.Single(s=>s.Name=="available").ID},
                new BookCopy{BookID = books.Single(b=>b.Name=="������� ����� �� ����� ��������������� �������").ID, StatusID = statuses.Single(s=>s.Name=="given away").ID},
                new BookCopy{BookID = books.Single(b=>b.Name=="������� ����� �� ����� ��������������� �������").ID, StatusID = statuses.Single(s=>s.Name=="reading room").ID},
                new BookCopy{BookID = books.Single(b=>b.Name=="������� ����� � ���������� �� ��������������� �������").ID, StatusID = statuses.Single(s=>s.Name=="available").ID}
            };
            foreach (var bookCopy in bookCopies)
            {
                var bookCopyInDB =
                    context.BookCopies.SingleOrDefault(
                        b => b.BookID == bookCopy.BookID && b.StatusID == bookCopy.StatusID);
                if (bookCopyInDB == null) context.BookCopies.Add(bookCopy);
            }
            context.SaveChanges();


            List<RequestType> requestTypes = new List<RequestType>
            {
                new RequestType{ Name = "read"},
                new RequestType{ Name = "take"}
            };
            requestTypes.ForEach(r => context.RequestTypes.AddOrUpdate(t => t.Name, r));
            context.SaveChanges();

            List<ReadingCard> readingCards = new List<ReadingCard>
            {
                new ReadingCard
                {
                    Name = "Borys",
                    LastName = "Symonenko",
                    SecondName = "Oleksandrovych",
                    BirthDate = DateTime.Now,
                    Passport = "3434434",
                    PhoneNumber = "+34344343",
                    PlaceOfWork = "university",
                    WorkPosition = "student",
                    RegistrationDate = DateTime.Now
                },
                new ReadingCard
                {
                    Name = "Oleksandr",
                    LastName = "Grebeniuk",
                    SecondName = "Unknown",
                    BirthDate = DateTime.Now,
                    Passport = "3434465",
                    PhoneNumber = "+343423343",
                    PlaceOfWork = "university",
                    WorkPosition = "student",
                    RegistrationDate = DateTime.Now
                }
            };
            readingCards.ForEach(r=>context.ReadingCards.AddOrUpdate(t=>t.Passport, r));
            context.SaveChanges();
        }
    }
}
