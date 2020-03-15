(defblock :name get-publisher-status :is-top t
	(worker
		:worker-name get-publisher-status
		:verb "status"
		:description "Gets status of the publisher."
		:usage-samples (
			"pub status"))

	(end)
)
