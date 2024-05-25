# MiniShop IDS


## 使用 dockerfile 构建部署

```shell
# 创建镜像
docker build -t minishopids -f Dockerfile .

# 启动容器
docker run -d -p 15101:80 --restart=always -v D:/dockervolumes/minishopids/appsettings.json:/app/appsettings.json -v D:/dockervolumes/minishopids/log:/app/log --name minishopids minishopids
```

## Jinkins 构建脚本

```shell
#!/bin/bash
echo "获取当前容器是否存在-----------------------------------------------------------------"
containerps=$(docker ps -f name=minishopids -q)
containerstop=$(docker ps -a -f name=minishopids -q)
for alpha in "$containerps";do
    if [ "$alpha" == "" ];then
    echo "检查是否存在停止的容器-------------------------------------------------"
        for alpha1 in "$containerstop";do
          if [ "$alpha1" == "" ];then
          echo "不存指定容器-----------------------------------"
          else
          echo "存在停止了的 然后直接删除-----------开始------------------"
          docker rm $alpha1
          echo "存在停止了的 然后直接删除-----------完成------------------"
        fi
       done
    else
    echo "存在-停止运行 然后删除----------------------开始-----------------"
    docker stop $alpha
    docker rm $alpha
     echo "存在-停止运行 然后删除---------------------完成------------------"
    fi
done

echo "获取当前镜像是否存在-----------------------------------------------------------------"
dockerlist=$(docker images minishopids:latest -q)
for alpha2 in "$dockerlist";do
  if [ "$alpha2" == "" ];then
     echo "不存在指定镜像-------------------------------------------------" 
  else
       echo "存在当前指定的镜像 删除镜像--------------开始-----------------------------------"
      docker rmi $alpha2
     echo "存在当前指定的镜像 删除镜像--------------完成-----------------------------------"
  fi
done

cd $WORKSPACE
echo $WORKSPACE

#版本号
image_version=`date +%Y%m%d%H%M`
docker build -t minishopids:$image_version .

echo "启动容器-------------------------------------------------"
docker run -d -p 15101:80 --restart=always -v /home/myvolumes/minishopids/appsettings.json:/app/appsettings.json -v /home/myvolumes/minishopids/log:/app/log --name minishopids minishopids:$image_version

```



