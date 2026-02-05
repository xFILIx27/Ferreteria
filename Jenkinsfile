pipeline {
    agent any
    stages {
        stage('Restore') {
            steps {
                bat "cd FerreteriaDiego"
                bat 'dotnet restore FerreteriaDiego/FerreteriaDiego.csproj'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build FerreteriaDiego/FerreteriaDiego.csproj'
            }
        }

        stage('Test') {
            steps {
                
                bat 'dotnet test TestFactura/TestFactura.csproj'
            }
        }
    }
}
