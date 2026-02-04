pipeline {
    agent any
    stages {
        stage('Restore') {
            steps {
                bat 'dotnet restore FerreteriaDiego.sln'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build FerreteriaDiego.sln --configuration Release'
            }
        }

        stage('Test') {
            steps {
                bat 'dotnet test FerreteriaDiego.sln --configuration Release --no-build'
            }
        }
    }
}
