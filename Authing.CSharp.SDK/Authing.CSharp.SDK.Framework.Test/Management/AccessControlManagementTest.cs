﻿using Authing.CSharp.SDK.Models;
using Authing.CSharp.SDK.Services;
using Authing.CSharp.SDK.Utils;
using Authing.CSharp.SDK.UtilsImpl;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Authing.CSharp.SDK.Framework.Test
{
    class AccessControlManagementTest
    {
        ManagementClient managementClient;

        IDateTimeService dateTimeService;

        [SetUp]
        public void Setup()
        {
            ManagementClientOptions options = new ManagementClientOptions()
            {
                AccessKeyId = "613189b2eed393affbbf396e",
                AccessKeySecret = "ccf4951a33e5d54d64e145782a65f0a7"
            };

            managementClient = new ManagementClient(options);
            dateTimeService = new DateTimeService();
        }


        [Test]
        public async Task CreateResourceTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                CreateResourceDto createResourceDto = new CreateResourceDto()
                {
                    Code = "ecs",
                    Description = "服务器",
                    Type = CreateResourceDto.type.API,
                    Actions = new List<ResourceAction> 
                    { 
                        new ResourceAction 
                        {
                            Name = "ecs:start", 
                            Description = "启动 ECS 服务器" 
                        } ,
                         new ResourceAction 
                        { 
                            Name = "ecs:stop", 
                            Description = "启动 ECS 服务器" 
                        }
                    },
                    ApiIdentifier = "https://my-awesome-api.com/api",
                    Namespace = "default"
                };

                ResourceRespDto dto =await managementClient.CreateResource(createResourceDto);

                Assert.IsTrue(dto.Data.Code == "ecs");
            }
        }

        [Test]
        public async Task CreateResourceBatchTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                CreateResourcesBatchDto createResourcesBatchDto = new CreateResourcesBatchDto()
                {
                    List = new List<CreateResourceBatchItemDto> 
                    {
                        new CreateResourceBatchItemDto
                        {
                            Code = "ecs" ,
                            Description = "服务器" ,
                            Type = CreateResourceBatchItemDto.type.API,
                            Actions = new List<ResourceAction>
                            {
                                new ResourceAction
                                {
                                    Name = "ecs:start",
                                    Description = "启动 ECS 服务器"
                                } ,
                                 new ResourceAction
                                {
                                    Name = "ecs:stop",
                                    Description = "启动 ECS 服务器"
                                }
                            },
                            ApiIdentifier = "https://my-awesome-api.com/api",
                        }
                    },
                    Namespace = "default"
                };

                IsSuccessRespDto dto =await managementClient.CreateResourcesBatch(createResourcesBatchDto);

                Assert.IsTrue(dto.Data.Success);
            }
        }

        [Test]
        public async Task GetResourceTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                ResourceRespDto dto =await managementClient.GetResource("ecs", "default");

                Assert.IsTrue(dto.Data.Code == "ecs");
            }
        }

        [Test]
        public async Task GetResourceBatchTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                ResourceListRespDto dto =await managementClient.GetResourcesBatch(string.Join(",", new List<string> { "ecs", "ecs1", "ecs2" }), "default");

                Assert.IsTrue(dto.Data.Count == 3);
            }
        }

        [Test]
        public async Task ListResourcesTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                ResourcePaginatedRespDto dto =await managementClient.ListResources("default");

                Assert.IsTrue(dto.Data.List.Count > 0);
            }
        }

        [Test]
        public async Task UpdateResourceTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                var resource = managementClient.GetResource("ecs", "default").Result;

                UpdateResourceDto updateResourceDto = new UpdateResourceDto()
                {
                    Code = resource.Data.Code,
                    Actions = resource.Data.Actions,
                    Description = "update",
                    Type = UpdateResourceDto.type.API,
                    Namespace = resource.Data.Namespace
                };

                ResourceRespDto dto =await managementClient.UpdateResource(updateResourceDto);

                Assert.IsTrue(dto.Data.Code == resource.Data.Code);
            }
        }

        [Test]
        public async Task DeleteResourceTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                var resource = managementClient.GetResource("ecs", "default").Result;

                DeleteResourceDto deleteResourceDto = new DeleteResourceDto()
                {
                    Code = "ecs",
                    Namespace = "default"
                };

                IsSuccessRespDto dto =await managementClient.DeleteResource(deleteResourceDto);

                Assert.IsTrue(dto.Data.Success);
            }
        }

        [Test]
        public async Task DeleteResourceBatchTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {

                DeleteResourcesBatchDto deleteResourcesBatchDto = new DeleteResourcesBatchDto()
                {
                    CodeList = new List<string> { "code1", "code2" },
                    Namespace = "default"
                };

                IsSuccessRespDto dto =await managementClient.DeleteResourcesBatch(deleteResourcesBatchDto);

                Assert.IsTrue(dto.Data.Success);
            }
        }

        [Test]
        public async Task CreateNameSpaceTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                CreateNamespaceDto createNamespaceDto = new CreateNamespaceDto()
                {
                    Code = "my-namespace",
                    Name = "我的权限分组",
                    Description = "我的权限分组描述"
                };

                NamespaceRespDto dto =await managementClient.CreateNamespace(createNamespaceDto);

                Assert.IsTrue(dto.Data.Code == "my-namespace");
            }
        }

        [Test]
        public async Task CreateNameSpaceBatchTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                CreateNamespacesBatchDto createNamespacesBatchDto = new CreateNamespacesBatchDto()
                {
                    List = new List<CreateNamespacesBatchItemDto>
                    {
                        new CreateNamespacesBatchItemDto()
                            {
                                Code = "my-namespace",
                                Name = "我的权限分组",
                                Description = "我的权限分组描述"
                            }
                    }
                };

                IsSuccessRespDto dto =await managementClient.CreateNamespacesBatch(createNamespacesBatchDto);

                Assert.IsTrue(dto.Data.Success);
            }
        }

        [Test]
        public async Task GetNameSpaceTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {

                NamespaceRespDto dto =await managementClient.GetNamespace("default");

                Assert.IsTrue(dto.Data.Code == "default");
            }
        }

        [Test]
        public async Task GetNameSpaceBatchTest()
        {

            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                NamespaceListRespDto dto =await managementClient.GetNamespacesBatch(string.Join(",", new List<string> { "default","system"}));

                Assert.IsTrue(dto.Data.Count == 2);
            }
        }

        [Test]
        public async Task UpdateNameSpaceTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                UpdateNamespaceDto updateNamespaceDto = new UpdateNamespaceDto()
                {
                    Code = "my-namespace",
                    Name = "我的权限分组",
                    Description = "示例应用的描述",
                    NewCode = "my-new-namespace"
                };


                UpdateNamespaceRespDto dto =await managementClient.UpdateNamespace(updateNamespaceDto);

                Assert.IsTrue(dto.Data.Name == "我的权限分组");
            }
        }

        [Test]
        public async Task DeleteNameSpaceTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                DeleteNamespaceDto deleteNamespaceDto = new DeleteNamespaceDto()
                {
                    Code = "my-new-namespace",
                };

                IsSuccessRespDto dto =await managementClient.DeleteNamespace(deleteNamespaceDto);

                Assert.IsTrue(dto.Data.Success);
            }
        }

        [Test]
        public async Task DeleteNameSpaceBatchTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {

                DeleteNamespacesBatchDto deleteNamespacesBatchDto = new DeleteNamespacesBatchDto()
                {
                    CodeList = new List<string> { "my-new-namespace" }
                };

                IsSuccessRespDto dto =await managementClient.DeleteNamespacesBatch(deleteNamespacesBatchDto);

                Assert.IsTrue(dto.Data.Success);
            }
        }

        [Test]
        public async Task AuthorizedResourcesTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                List<ResourceAction> resourceActions = new List<ResourceAction>();
                resourceActions.Add(new ResourceAction { Name = "ecs:start", Description = "启动 ECS 服务器" });
                resourceActions.Add(new ResourceAction { Name = "ecs:stop", Description = "启动 ECS 服务器" });

                List<AuthorizeResourceItem> items = new List<AuthorizeResourceItem>();

                List<ResourceItemDto> resourceItemDtos = new List<ResourceItemDto>();
                resourceItemDtos.Add(new ResourceItemDto { Actions = new List<string> { "ecs:start", "ecs:stop" }, Code = "ecs", ResourceType = ResourceItemDto.resourceType.API });



                items.Add(new AuthorizeResourceItem { TargetType = AuthorizeResourceItem.targetType.USER, TargetIdentifiers = new List<string> { "61c1866a342c23ec8a6431fe" }, Resources = resourceItemDtos });

                AuthorizeResourcesDto authorizedResourceDto = new AuthorizeResourcesDto()
                {
                    Namespace = "default",
                    List = items
                };

                IsSuccessRespDto dto =await managementClient.AuthorizeResources(authorizedResourceDto);

                Assert.IsTrue(dto.Data.Success);
            }
        }

        [Test]
        public async Task GetAuthorizedResourcesTest()
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                AuthorizedResourcePaginatedRespDto dto =await managementClient.GetAuthorizedResources("61c1866a342c23ec8a6431fe", "USER", "default", "API");

                Assert.IsTrue(dto.Data.List.Count>0);
            }
        }
    }
}