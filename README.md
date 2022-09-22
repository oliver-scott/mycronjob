# MyCronJob
Sample .NET cron job application for Kubernetes

## Getting started
In the steps below, and in the kube.yml files in this solution, replace `my-registry-host` with the name of your container registry/docker repository

1. cd into the solution root
2. Build the docker image

```
docker build . -f ./MyCronJob/Dockerfile -t my-registry-host/mycronjob:latest
```

3. Push the docker image to your repository

```
docker push my-registry-host/mycronjob:latest
```

4. Install `kubectl` if you haven't already, then ensure you are connected to the kubernetes cluster

```
# Use the context to select the kubernetes cluster
# Replace context-name with the name of your kubernetes context
kubectl config use-context context-name

# Check that you can view the pods
kubectl get pods
```

5. Create the cron job in Kubernetes

Job 1:

```
kubectl create -f ./MyCronJob/Job1/kube.yml
```

Job 2:

```
kubectl create -f ./MyCronJob/Job2/kube.yml
```

6. When a job runs, a pod will be created. This will run the relevant background service to completion/failure and then stop the application.