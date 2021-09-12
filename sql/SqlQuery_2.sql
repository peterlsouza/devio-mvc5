﻿CREATE TABLE [dbo].[Enderecos] (
    [Id] [uniqueidentifier] NOT NULL,
    [Logradouro] [varchar](200) NOT NULL,
    [Numero] [varchar](50) NOT NULL,
    [Complemento] [varchar](250),
    [CEP] [varchar](8) NOT NULL,
    [Bairro] [varchar](100) NOT NULL,
    [Cidade] [varchar](100) NOT NULL,
    [Estado] [varchar](50) NOT NULL,
    CONSTRAINT [PK_dbo.Enderecos] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Fornecedores] (
    [Id] [uniqueidentifier] NOT NULL,
    [Nome] [varchar](200) NOT NULL,
    [Documento] [varchar](14) NOT NULL,
    [TipoFornecedor] [int] NOT NULL,
    [Ativo] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.Fornecedores] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Produtos] (
    [Id] [uniqueidentifier] NOT NULL,
    [FornecedorId] [uniqueidentifier] NOT NULL,
    [Nome] [varchar](200) NOT NULL,
    [Descricao] [varchar](1000) NOT NULL,
    [Imagem] [varchar](100) NOT NULL,
    [Valor] [decimal](18, 2) NOT NULL,
    [DataCadastro] [datetime] NOT NULL,
    [Ativo] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.Produtos] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Id] ON [dbo].[Enderecos]([Id])
CREATE INDEX [IX_FornecedorId] ON [dbo].[Produtos]([FornecedorId])
ALTER TABLE [dbo].[Enderecos] ADD CONSTRAINT [FK_dbo.Enderecos_dbo.Fornecedores_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[Fornecedores] ([Id])
ALTER TABLE [dbo].[Produtos] ADD CONSTRAINT [FK_dbo.Produtos_dbo.Fornecedores_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [dbo].[Fornecedores] ([Id])
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'202108261242250_AutomaticMigration', N'Pet.Infra.Migrations.Configuration',  0x1F8B0800000000000400E55BDB6EDB46107D2FD07F20F85838A2E534406A48096CD90ED446B661D941DE8C15399217257719EED2B010F4CBFAD04FEA2F7428DE96CB8B2889726D0479B1F672766776E6EC7066F3EFDFFF0C3E3E79AEF10881A09C0DCD7EEFD03480D9DCA16C313443397FF3DEFCF8E1E79F06E78EF7647C49C7BD8DC6E14C2686E68394FEB16509FB013C227A1EB5032EF85CF66CEE59C4E1D6D1E1E16F56BF6F014298886518839B9049EAC1EA07FE1C7166832F43E24EB803AE48DAB167BA42352E8907C227360CCD6B90BD319B07A4774624E9E154094FD2344E5C4A70375370E7A64118E39248DCEBF19D80A90C385B4C7D6C20EEEDD2071C3727AE804486E37C785B710E8F2271AC7C620A658742726F43C0FEDB443F963E7D2B2D9B99FE5083E7A869B98CA45E6971689E330702B0B969E88B1D8FDC201A182BF93414948110BDF84C7A173C606083C30310BD14E4C050871E6416828614FD3B3046A12BC300860C42191017C7873397DA7FC0F296FF096CC842D755F78B3BC6BE4203365D07DC87402E6F609E4831764CC32ACEB3F489D934654E2CDFA790E2DF97B83699B9905983D538FD335F04A8E930E0290C1A16FA89694CC8D367600BF93034F1184CE3823E8193B624D8778CA25BE1241984B0F1DA97A1078DEBBEDBCBB223EEF92E78C064A3CC2D175FB3D6F975C31AEFB51562C4DDA43B253468546A7F3F8739A20E71E0F9D73D1712ED77FF4674491EE962C528DA06720A318D1B705743C403F563DA5618E63E27A98B807B37DC2DCCCEBAEF6F49B00064FF5B5E3F668A2E6B6BBB1C58392F36B2A5BAE51DF832FFF12331E625F79ACC7C4F5C79C6ED701D65F57FDDC7CAB7D4E7AAC124CB47B6AD776D887C22E96326CF29475B276C0747CCDDAB1B374C5DACC90D53576DBB47FCE984928BCA3D269DF7AA4AF32D967B4B44513164279E48F036258954C8F48F1F891D72D5BF4E9A016107D4266B0288BDAC3DF6C802BCE78F20BE1037E7B533B0A9475CD3B846FFA6C90724C669539B4480479B6B143FE846C42142E65119B6C12DF536DF6AC78CB92674D9988F74C66CA0AC767C147A0A1BE9B7CD585CB864917FF6EE10C914A1BBE12BB44ABC24DC255A71BC8B31936F8F341A9B80378320A55B5C8D930BB43A9B98069A65888DFDD27156CCF93D0CA8A3CE3A2A6B38D6A5DA7882536DBAD255C920F25BB2B838361B2DAECC3C46504F6C827AA33E6A0A0FBB4AB266F0ECB6CBC1F3AB7C1D345E0A389245C992111A391E1B65B27C835066539FB8EB45D4A6B6BC7EA293C816D17BCEC0075C85C9F53AD87EF56C11ED5A5CA79F81A5584BB31155D046DD313771487ECA5918523CE45F1AECA72958DACE36B732A0FA6D3C83FDD42BB7CDE2C540E6190C29BE03A2D427CEC8F86D02E1D92CCB879628FE4E40C2F222B9FD758B8840A720B56F040CC0F33BA7442625B32A82A85747058E6A556B90F2CF81124A66F41A84A2BDAA1D295F37CAC8868F20FD60DB117C2688AE8D92A1B4E374054F39223D762FCADE422F55114C592DEB08AB2D652942E407DBA09006926AA9DF0695A44155E65079FDC18A0B1069A1C2AAA9540C26C4F7317A512A17498B318DCB16A337D3CD73F95E8C61D9A222A59FED365B49F2003F0BB4DE2889EBC0050D848CE2EB1989E2BF91E3958615E8A3C617D3A57486281F5CEAA2E98CE8EF340CAB2AE0F4EABC2C57E5054A17E575568242851B94A7AE2A48C42541C597EB88BBA1C7EAAF8FFAD96A21404551DBDBA3A5A97D15296D6B8F52C8D4AB50858E0DF0A26C7C01276A683F3FCDADAB1069DB06BB4832E5858D246DED51D2BCB78A92B695510696666FA5FBBC64DD1AD1E8EED2CA990ADCD5813FD533740B8F6A9ABC1F9F8A7338051F58B5B44750D2BE2A8CD2DC1E4BFF7E5601F5BEF6A8494A42054B9A5E8C1566977107169886659B9B5FEDCCFDD85E317E57719A23FB7AC40EAC39CF2E16AC396F6E8F95660B0B1A4ADADAA324B93F152469DA40AA4286AF2058A1E715FA542988D48764AB67C1A416340E92006EFD1B985244170F8932B1FC913A5134375D0A095EEC90D36FEEC8A5286F3E6042189D83907112CE3C3AEC1F694F685ECE73164B08C7DDFA4DCB18BB9E86E677E3AFE72F8B848C7E0B81469FFE744EA1AA849C6D2F9A7B6C8CBFDE8F9D03E32A40798E8D43DCF4EEAF541E49603F90A05C13D9E90D4A15EABBCD412B5E9854EEB708BDE17B922AC4F73B3E17A9C2EC6FA1D5E26390AE508B4F3DB63AAB6E9E48BC2CF7DBA1B0D89517955E2764C065DD7DBDCF46473511D4E449DE6B7C37C6E26E25E2B1718B0E119185F6C4A193F70B34BA3876A9BECDE83A800ECAECAFDAD0AA4AE15B5D1E2AD04ED7C85E4C5FAF98D7B0DDE6C8C57A7857245AA8763BCF51ED768804B973B57B7B7FEBAACCD94159330FE95A14310F7BBDCEEB98CF51776A487ABECE2A65A7269091FD3605CE5770FAF50992175B632CD712DA15111B6B88F1D72BB2DF2C3AEB98B4EA4B5BF525C63505C6AA651A2B463525C8A60A64D51A7505AEFFA53E59532F6B2CBEE987582CBABCC8D2E36E026B075DC849EEA5AC58CEFCA0E72AFF470AA943D0450E11FD8F2914A4E0B3D998319BF39440B41DA543B4E86102F8B5880E7D1260A8496C89DD3608B17A5498BC923AF766E08CD95528FD50A2C8E0CDDCA5AA8C88829AD65FD54E8B7B1E5CF9AB67745D8880DBA451F474C54E43EA3AD9BE2F2A829F1A8888DB3E01B6C76789542961B1CC902E396B0994A82FA3E45BF07C17C1C4159B9247D8666F77023EC382D8CB3481570FB2FE208A6A1F9C51B2088827128C7C3EFE441B76BCA70FFF01CD48A4D82A380000 , N'6.4.4')

