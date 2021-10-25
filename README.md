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
This method gets a video by it's ID
{% endswagger-description %}

{% swagger-parameter in="path" required="true" type="Integer" name="id" %}
ID of the video to retrieve
{% endswagger-parameter %}

{% swagger-parameter in="query" name="active" type="Boolean" required="false" %}
Filters for only active records if set to

**true**
{% endswagger-parameter %}

{% swagger-response status="200: OK" description="A video url" %}
```javascript
{
    "url":"http://youtube.com/
}
```
{% endswagger-response %}
{% endswagger %}
