const express = require('express');
const path = require('path');
const app = express();
const port = 8085;

// 정적 파일(html)을 제공하기 위한 미들웨어 설정
app.use(express.static(path.join(__dirname, 'template')));

// 정적 파일(css, js, image)을 제공하기 위한 미들웨어 설정
app.use('/static', express.static(path.join(__dirname, 'static'), { 
    setHeaders: (res, path) => {
        if (path.endsWith('.css')) {
            res.setHeader('Content-Type', 'text/css');
        }
    },
}));

// 부트스트랩을 제공하기 위한 미들웨어 설정
app.use('/bootstrap', express.static(path.join(__dirname, 'node_modules/bootstrap/dist')));

// 루트 경로에 대한 응답
app.get('/', (req, res) => {
    res.sendFile(path.join(__dirname, 'template', 'index.html'));
});

// 서버 시작
app.listen(port, () => {
    console.log(`Server is running at http://localhost:${port}`);
});