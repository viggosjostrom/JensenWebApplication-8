let currentPage = 1;
let pageSize = 12; // Default page size

document.getElementById('load-more').addEventListener('click', loadMoreNews);

function loadMoreNews() {
    console.log('Load more news button clicked');
    currentPage++;
    fetch(`/api/articles?page=${currentPage}&pageSize=${pageSize}`)
        .then(response => response.json())
        .then(data => {
            const newsContainer = document.getElementById('news-container');
            data.forEach(article => {
                const articleElement = document.createElement('div');
                articleElement.className = 'col-md-6 col-lg-4 mb-4 news-article';
                articleElement.innerHTML = `
                    <div class="card">
                        <div class="card-body">
                            <h5 class="card-title">${article.title}</h5>
                            <p class="card-text">${article.summary}</p>
                            <a href="${article.link}" class="card-link" target="_blank">Read More</a>
                            <p class="card-text"><small class="text-muted">${new Date(article.published).toLocaleString()}</small></p>
                        </div>
                    </div>`;
                newsContainer.appendChild(articleElement);
            });
        })
        .catch(error => console.error('Error loading more news:', error));
}
