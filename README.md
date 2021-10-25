---
description: 'TODO: Put some clever text here'
---

# This is my GitHub Sync

| Tasks                  | Desc                         |
| ---------------------- | ---------------------------- |
| Check it out in GitHub | Visit the branch on GitHub   |
| Make some changes      | Add some sample content here |
| Add some content       | Perhaps a new page?          |

{% embed url="https://youtu.be/PE9eUYzij3o" %}
This game kicks butt!
{% endembed %}

{% swagger method="get" path="/www.solidrocketfuel/api/v1/video/{id}" baseUrl="https:/" summary="Gets a video by `id`" %}
{% swagger-description %}

{% endswagger-description %}

{% swagger-parameter in="path" required="true" %}

{% endswagger-parameter %}

{% swagger-response status="200: OK" description="A video url" %}
```javascript
{
    "url":"http://youtube.com/
}
```
{% endswagger-response %}
{% endswagger %}
